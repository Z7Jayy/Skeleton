using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    public class LoginController : Controller
    {
        private readonly string connectionString = "YourConnectionString";

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM users WHERE username = @Username";
                var user = await connection.QueryFirstOrDefaultAsync<User>(query, new { Username = username });

                if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    HttpContext.Session.SetInt32("user_id", user.Id);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid username or password.";
                    return View();
                }
            }
        }
    }
    
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
