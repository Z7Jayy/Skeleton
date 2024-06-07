using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    public class SignupController : Controller
    {
        private readonly string connectionString = "YourConnectionString";

        [HttpPost]
        public async Task<IActionResult> Signup(string username, string password, string email)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            using (var connection = new SqlConnection(connectionString))
            {
                var query = "INSERT INTO users (username, password, email) VALUES (@Username, @Password, @Email)";
                var parameters = new { Username = username, Password = hashedPassword, Email = email };

                try
                {
                    await connection.ExecuteAsync(query, parameters);
                    ViewBag.Message = "User registered successfully.";
                }
                catch (SqlException ex)
                {
                    ViewBag.ErrorMessage = "Error: " + ex.Message;
                }

                return View();
            }
        }
    }
}
