using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    public class ProfileController : Controller
    {
        private readonly string connectionString = "YourConnectionString";

        public async Task<IActionResult> Index()
        {
            if (!HttpContext.Session.TryGetValue("user_id", out var userIdBytes))
            {
                return RedirectToAction("Login", "Login");
            }

            var userId = BitConverter.ToInt32(userIdBytes, 0);

            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM users WHERE id = @UserId";
                var user = await connection.QueryFirstOrDefaultAsync<User>(query, new { UserId = userId });

                if (user == null)
                {
                    return RedirectToAction("Login", "Login");
                }

                return View(user);
            }
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}

[HttpPost]
public async Task<IActionResult> UpdateProfile(string username, string email)
{
    if (!HttpContext.Session.TryGetValue("user_id", out var userIdBytes))
    {
        return RedirectToAction("Login", "Login");
    }

    var userId = BitConverter.ToInt32(userIdBytes, 0);

    using (var connection = new SqlConnection(connectionString))
    {
        var query = "UPDATE users SET username = @Username, email = @Email WHERE id = @UserId";
        var parameters = new { Username = username, Email = email, UserId = userId };

        try
        {
            await connection.ExecuteAsync(query, parameters);
            ViewBag.Message = "Profile updated successfully.";
        }
        catch (SqlException ex)
        {
            ViewBag.ErrorMessage = "Error: " + ex.Message;
        }

        return View("Index"); // Assuming the update profile view is named 'Index'
    }
}
