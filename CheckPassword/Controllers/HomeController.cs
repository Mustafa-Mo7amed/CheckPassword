using System.Diagnostics;
using CheckPassword.Models;
using CheckPassword.Services;
using Microsoft.AspNetCore.Mvc;

namespace CheckPassword.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPasswordService _passwordService;

        public HomeController(ILogger<HomeController> logger, IPasswordService passwordService)
        {
            _logger = logger;
            _passwordService = passwordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Example method to check if a password hash exists in the database
        public async Task<IActionResult> CheckPassword(string hash)
        {
            if (string.IsNullOrEmpty(hash))
            {
                return BadRequest("Hash is required");
            }

            var isPwned = await _passwordService.IsPasswordPwnedAsync(hash);

            return Json(new { isPwned = isPwned });
        }

        // Example method to get total password count
        public async Task<IActionResult> GetPasswordCount()
        {
            var count = await _passwordService.GetPasswordCountAsync();
            return Json(new { count = count });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
