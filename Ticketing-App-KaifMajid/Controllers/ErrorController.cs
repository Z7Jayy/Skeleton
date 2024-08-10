using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class ErrorController : Controller
{
    [HttpGet]
    public IActionResult Error()
    {
        TempData["ErrorMessage"] = "UnAuthorized Access";

        return RedirectToAction("Login", "Login");
    }
}