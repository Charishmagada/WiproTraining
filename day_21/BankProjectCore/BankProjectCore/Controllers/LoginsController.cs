using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankProjectCore.Models;
using BankProjectCore.Middleware;

namespace BankProjectCore.Controllers
{
    [ApiController] // Ensures Swagger & model binding works well
    [Route("api/[controller]")] // Base route will be: api/Logins
    public class LoginsController : ControllerBase
    {
        private readonly BankDbContext _context;

        public LoginsController(BankDbContext context)
        {
            _context = context;
        }

        // GET: api/Logins/login/{username}/{password}
        [HttpGet("login/{username}/{password}")]
        public async Task<ActionResult<string>> Login(string username, string password)
        {
            // Check if user exists
            Login loginFound = await _context.Logins
                .Where(x => x.UserName == username)
                .FirstOrDefaultAsync();

            if (loginFound == null)
            {
                return "0"; // User not found
            }

            // Decrypt stored password
            string? encry = loginFound.Password;
            string pwd = DecryptionHelper.Decrypt(encry);

            // Compare with given password
            if (pwd.Equals(password))
            {
                return "1"; // Login success
            }

            return "0"; // Wrong password
        }

        // POST: api/Logins
        [HttpPost]
        public async Task<ActionResult<string>> PostLogin(Login login)
        {
            // Encrypt password before saving
            string pwd = EncryptionHelper.Encrypt(login.Password);
            login.Password = pwd;

            _context.Logins.Add(login);
            await _context.SaveChangesAsync();

            return "Account Created Successfully.";
        }

        // DELETE: api/Logins/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogin(int id)
        {
            var login = await _context.Logins.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            _context.Logins.Remove(login);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoginExists(int id)
        {
            return _context.Logins.Any(e => e.Id == id);
        }
    }
}
