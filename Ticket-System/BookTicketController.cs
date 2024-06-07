using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    public class BookTicketController : Controller
    {
        private readonly string connectionString = "YourConnectionString";

        [HttpPost]
        public async Task<IActionResult> BookTicket(int eventId, int seatNumber, decimal price)
        {
            if (!HttpContext.Session.TryGetValue("user_id", out var userIdBytes))
            {
                return RedirectToAction("Login", "Login");
            }

            var userId = BitConverter.ToInt32(userIdBytes, 0);

            using (var connection = new SqlConnection(connectionString))
            {
                var query = "INSERT INTO tickets (user_id, event_id, seat_number, price) VALUES (@UserId, @EventId, @SeatNumber, @Price)";
                var parameters = new { UserId = userId, EventId = eventId, SeatNumber = seatNumber, Price = price };

                try
                {
                    await connection.ExecuteAsync(query, parameters);
                    ViewBag.Message = "Ticket booked successfully.";
                }
                catch (SqlException ex)
                {
                    ViewBag.ErrorMessage = "Error: " + ex.Message;
                }

                return View("Index"); // Assuming there's a view named 'Index'
            }
        }
    }
}
