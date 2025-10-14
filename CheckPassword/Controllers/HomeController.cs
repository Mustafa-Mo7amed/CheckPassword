using System.Diagnostics;
using CheckPassword.Models;
using CheckPassword.Services;
using Microsoft.AspNetCore.Mvc;

namespace CheckPassword.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly IPasswordService _passwordService;

        public HomeController(ILogger<HomeController> logger, IPasswordService passwordService) {
            _logger = logger;
            _passwordService = passwordService;
        }

        public IActionResult Index() {
            return View();
        }
    }
}
