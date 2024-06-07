using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace YourNamespace.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}
