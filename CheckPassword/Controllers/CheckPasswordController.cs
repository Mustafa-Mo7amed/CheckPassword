using CheckPassword.Models;
using CheckPassword.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CheckPassword.Controllers {
    public class CheckPasswordController : Controller {
        private readonly ILogger<CheckPasswordController> _logger;
        private readonly IPasswordService _passwordService;

        public CheckPasswordController(ILogger<CheckPasswordController> logger, IPasswordService passwordService) {
            _logger = logger;
            _passwordService = passwordService;
        }
        public IActionResult Index() {
            return View();
        }

        public async Task<IActionResult> Validate(string password) {
            int score = 0;
            if (password.Length < 6)
                score -= 10000000;
            if (password.Length < 8)
                score -= 20;
            var passwordExist = await _passwordService.GetPassword(password);
            if (passwordExist != null)
                score -= 10000000;

            if (password.Length >= 8)
                score += 5;

            if (password.Length >= 12)
                score += 10;

            var eval = new Evaluation();
            int charSetSize = 0;
            if (password.Any(Char.IsUpper)) {
                score += 10;
                eval.HasUpper = true;
                charSetSize += 26;
            }
            if (password.Any(Char.IsLower)) {
                score += 10;
                eval.HasLower = true;
                charSetSize += 26;
            }
            if (password.Any(Char.IsNumber)) {
                score += 10;
                eval.HasNumber = true;
                charSetSize += 10;
            }
            string symbols = "!@#$%^&*()-_=+[]{};:'\",.<>?/\\|`~";
            if (password.Any(c => symbols.Contains(c))) {
                score += 15;
                eval.HasSymbol = true;
                charSetSize += symbols.Length;
            }
            double entropy = password.Length * Math.Log2(charSetSize);
            eval.Entropy = entropy;
            if (entropy >= 40 && entropy < 60)
                score += 10;
            else if (entropy >= 60 && entropy < 80)
                score += 20;
            else if (entropy >= 80 && entropy < 100)
                score += 30;
            else if (entropy >= 100)
                score += 40;
            eval.Score = score;
            return View(eval);
        }
    }
}
