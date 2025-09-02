using Microsoft.AspNetCore.Identity;

namespace backend.Services
{
    public class PasswordService
    {
        private readonly PasswordHasher<object> _hasher = new PasswordHasher<object>();

        // Create a hashed password
        public string HashPassword(string password)
        {
            return _hasher.HashPassword(null!, password);
        }

        // Verify password-supports both hashed + plain text
        public bool VerifyPassword(string storedPassword, string providedPassword)
        {
            try
            {
                var result = _hasher.VerifyHashedPassword(null!, storedPassword, providedPassword);
                return result == PasswordVerificationResult.Success ||
                       result == PasswordVerificationResult.SuccessRehashNeeded;
            }
            catch (FormatException)
            {
                // Stored value wasn't a real hash - treat as plain text
                return storedPassword == providedPassword;
            }
        }
    }
}
