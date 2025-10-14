using Microsoft.AspNetCore.Mvc;

namespace CheckPassword.Controllers {
    public class CheckPasswordController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
