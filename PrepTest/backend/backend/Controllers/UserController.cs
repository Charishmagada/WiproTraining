using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using backend.Models;
using System.Threading.Tasks;

[Authorize(Roles = "User")]
public class UserController : Controller
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        var username = User.Identity?.Name;
        if (string.IsNullOrEmpty(username))
            return RedirectToAction("Login", "Account");

        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        if (user == null)
            return RedirectToAction("Login", "Account");

        return View(user);
    }
}
