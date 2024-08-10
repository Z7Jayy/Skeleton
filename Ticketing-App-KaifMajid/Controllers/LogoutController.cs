using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace WebApplication1.Controllers;

public class LogoutController : Controller
{
    private readonly string _connectionString = "Server=localhost;Database=test;User=root;Password=;";

    public async Task<IActionResult> Logout()
    {
        await using var connection = new MySqlConnection(_connectionString);

        var sessionId = HttpContext.Session.GetInt32("user_session_id");
        const string logoutQuery = "UPDATE User_Sessions SET is_active = @IsActive WHERE session_id = @SessionId";

        var param = new
        {
            IsActive = false,
            SessionId = sessionId
        };

        try
        {
            await connection.ExecuteAsync(logoutQuery, param);
            HttpContext.Session.Clear();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return RedirectToAction("Login", "Login");
    }
}