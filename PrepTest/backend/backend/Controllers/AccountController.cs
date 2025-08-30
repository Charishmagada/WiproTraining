using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using backend.Models;

public class AccountController : Controller
{
    private readonly AppDbContext _context;
    private readonly PasswordHasher<User> _passwordHasher;

    public AccountController(AppDbContext context)
    {
        _context = context;
        _passwordHasher = new PasswordHasher<User>();
    }

    // GET: Login
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    // POST: Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ViewBag.Message = "Username and password are required.";
            return View();
        }

        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        if (user == null)
        {
            ViewBag.Message = "Invalid credentials!";
            return View();
        }

        // Check if password is hashed (new users)
        bool passwordValid = false;
        if (!string.IsNullOrEmpty(user.PasswordHash) && user.PasswordHash.StartsWith("$"))
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            passwordValid = result == PasswordVerificationResult.Success;
        }
        else
        {
            // old seed users plain text
            passwordValid = user.PasswordHash == password;
        }

        if (!passwordValid)
        {
            ViewBag.Message = "Invalid credentials!";
            return View();
        }

        // Get user roles
        var roleIds = await _context.UserRoles
            .Where(ur => ur.UserId == user.Id)
            .Select(ur => ur.RoleId)
            .ToListAsync();

        var roles = await _context.Roles
            .Where(r => roleIds.Contains(r.Id))
            .Select(r => r.Name)
            .ToListAsync();

        // Create claims safely
        var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName!) };
        claims.AddRange(roles.Where(r => r != null).Select(r => new Claim(ClaimTypes.Role, r!)));

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        // Redirect based on role
        if (roles.Contains("Admin"))
            return RedirectToAction("Dashboard", "Admin");
        else
            return RedirectToAction("Profile", "User");
    }

    // GET: Register
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    // POST: Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(string username, string email, string password)
    {
        if (await _context.Users.AnyAsync(u => u.UserName == username))
        {
            ViewBag.Message = "Username already exists";
            return View();
        }

        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            UserName = username,
            Email = email ?? string.Empty
        };

        // Hash the password for new users
        user.PasswordHash = _passwordHasher.HashPassword(user, password);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        // Assign default role "User"
        _context.UserRoles.Add(new UserRole
        {
            UserId = user.Id,
            RoleId = "2" // User role
        });
        await _context.SaveChangesAsync();

        ViewBag.Message = "Registration successful! Please login.";
        return RedirectToAction("Login");
    }

    // POST: Logout
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }

    // GET: AccessDenied
    [HttpGet]
    public IActionResult AccessDenied()
    {
        ViewBag.Message = "Access Denied: You do not have permission to view this page.";
        return View();
    }
}
