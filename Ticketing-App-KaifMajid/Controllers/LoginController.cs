using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Authorize]
public class LoginController(IConfiguration config) : Controller
{
    private readonly IConfiguration _config = config;

    private readonly string _connectionString =
        "Server=localhost;Database=test;User=root;Password=;";


    [AllowAnonymous]
    [HttpGet]
    public IActionResult Login()
    {
        var userId = HttpContext.Session.GetInt32("userId");

        if (userId != null)
            return RedirectToAction("Profile", "Profile");


        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> User_Login([FromForm] string email, string password)
    {
        if (email.IsNullOrEmpty() || password.IsNullOrEmpty()) // Data Check
        {
            ViewBag.ErrorMessage = "Invalid username or password.";
            return View("Login");
        }

        await using var connection = new MySqlConnection(_connectionString); // Connection Initialization
        Console.WriteLine(connection.ConnectionString);

        const string query = "SELECT * FROM users WHERE email = @Email"; // Query for Getting User 

        try
        {
            var user = await connection.QueryFirstOrDefaultAsync<User>(query, new { Email = email }); // Execution

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password_Hash)) // Credential Check
            {
                Console.WriteLine(email + " " + password);
                var accessToken = GenerateToken(email, user.FirstName); // JWT Token Generation

                // Session and Context Variables Set up //
                HttpContext.Session.SetInt32("userId", user.UserId);
                HttpContext.Session.SetString("accessToken", accessToken);
                HttpContext.Session.SetString("email", user.Email);
                HttpContext.Session.SetString("SessionExpiresAt",
                    DateTime.UtcNow.AddMinutes(5).ToString(CultureInfo.InvariantCulture));

                HttpContext.Response.Headers.Authorization = "Bearer " + accessToken;

                Console.WriteLine(accessToken);

                // Session Storing Query
                const string sessionQuery =
                    "INSERT INTO User_Sessions (user_Id,login_time,is_active) VALUES (@UserId,@LoginTime,@IsActive)";

                var param = new // Query Parameters
                {
                    user.UserId,
                    LoginTime = DateTime.Now,
                    IsActive = true
                };


                // Execution
                await connection.ExecuteAsync(sessionQuery, param);

                // Get the newly created user session id
                const string userIdQuery = "SELECT LAST_INSERT_ID()";
                var sessionId = await connection.QuerySingleAsync<int>(userIdQuery);

                HttpContext.Session.SetInt32("user_session_id", sessionId);

                Console.WriteLine("Session Started With Id " + HttpContext.Session.Id);

                return RedirectToAction("Profile", "Profile");
            }
        }
        catch (MySqlException e)
        {
            Console.WriteLine(e);
            throw;
        }

        ViewBag.ErrorMessage = "Invalid username or password.";

        return View("Login");
    }

    private string GenerateToken(string email, string name)
    {
        var securityKey =
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["JwtSettings:Key"] ?? throw new InvalidOperationException()));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, email),
            new(ClaimTypes.Name, name)
        };

        var token = new JwtSecurityToken(
            _config.GetSection("JwtSettings:Issuer").Value,
            _config.GetSection("JwtSettings:Issuer").Value,
            claims,
            expires: DateTime.Now.AddMinutes(5), signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}