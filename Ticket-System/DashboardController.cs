using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace YourNamespace.Controllers
{
    public class DashboardController : Controller
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
                var query = "SELECT * FROM tickets WHERE user_id = @UserId";
                var tickets = await connection.QueryAsync<Ticket>(query, new { UserId = userId });

                return View(tickets);
            }
        }
    }

    public class Ticket
    {
        public int EventId { get; set; }
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
    }
}
