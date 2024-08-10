using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[Authorize]
public class DashboardController : Controller
{
    private readonly string _connectionString = "Server=localhost;Database=test;User=root;Password=;";

    public async Task<IActionResult> MyDashboard()
    {
        if (!HttpContext.Session.TryGetValue("userId", out var userIdBytes))
            return RedirectToAction("Login", "Login");

        var userId = BitConverter.ToInt32(userIdBytes, 0);

        /*
        await using var connection = new MySqlConnection(_connectionString);
        const string query = "SELECT * FROM tickets WHERE user_id = @UserId";
        var tickets = await connection.QueryAsync<Ticket>(query, new { UserId = userId });
        */

        return View();
    }
}

public class Ticket
{
    public int EventId { get; set; }
    public int SeatNumber { get; set; }
    public decimal Price { get; set; }
}