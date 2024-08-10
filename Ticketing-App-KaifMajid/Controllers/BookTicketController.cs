using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace WebApplication1.Controllers;

[Authorize]
public class BookTicketController : Controller
{
    private readonly string _connectionString = "Server=localhost;Database=test;User=root;Password=;";

    [HttpPost]
    public async Task<IActionResult> BookTicket(int eventId, int seatNumber, decimal price)
    {
        if (!HttpContext.Session.TryGetValue("userId", out var userIdBytes))
            return RedirectToAction("Login", "Login");

        var userId = BitConverter.ToInt32(userIdBytes, 0);

        using (var connection = new MySqlConnection(_connectionString))
        {
            var query =
                "INSERT INTO tickets (user_id, event_id, seat_number, price) VALUES (@UserId, @EventId, @SeatNumber, @Price)";
            var parameters = new { UserId = userId, EventId = eventId, SeatNumber = seatNumber, Price = price };

            try
            {
                await connection.ExecuteAsync(query, parameters);
                ViewBag.Message = "Ticket booked successfully.";
            }
            catch (MySqlException ex)
            {
                ViewBag.ErrorMessage = "Error: " + ex.Message;
            }

            return View("Index"); // Assuming there's a view named 'Index'
        }
    }
}