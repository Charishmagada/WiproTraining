using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly EmsDbContext _context;
        private readonly JwtSettings _jwtSettings;
        private readonly PasswordService _passwordService;

        public AuthService(EmsDbContext context, IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings.Value;
            _passwordService = new PasswordService();
        }

        public async Task<(string? Token, User? User)> Authenticate(string username, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                return (null, null);
            }

            bool passwordValid = false;

            if (!string.IsNullOrEmpty(user.PasswordHash))
            {
                // Try hashed verification
                try
                {
                    passwordValid = _passwordService.VerifyPassword(user.PasswordHash, password);
                }
                catch (FormatException)
                {
                    // Ignore if not a real hash (means it's plain text stored like "Siri123" or "hashedpwd2")
                }

                // Plain text fallback (treat anything like "Siri123" or "hashedpwd2" as normal password)
                if (!passwordValid && user.PasswordHash == password)
                {
                    passwordValid = true;

                    // Upgrade DB-proper hash (optional: you can comment this out if you want to keep plain)
                    user.PasswordHash = _passwordService.HashPassword(password);
                    await _context.SaveChangesAsync();
                }
            }

            if (!passwordValid)
            {
                return (null, null);
            }

            // Generate JWT claims (safe defaults for nulls)
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username ?? string.Empty),
                new Claim(ClaimTypes.Role, user.Role ?? "Employee"),
                new Claim("EmpId", (user.EmpId?.ToString()) ?? "0")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey ?? string.Empty));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationMinutes),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return (tokenString, user);
        }
    }
}
