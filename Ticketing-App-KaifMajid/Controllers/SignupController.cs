using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class SignupController : Controller
{
    private const string connectionString = "Server=localhost;Database=test;User=root;Password=;";


    [AllowAnonymous]
    [HttpGet]
    public IActionResult Signup()
    {
        var token = HttpContext.Session.GetString("accessToken");

        if (token != null) return RedirectToAction("MyDashboard", "Dashboard");
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> CreateUser(UserProfileViewModel model)
    {
        // Strict Password Policy ( Minimum 8 chars & Alpha-Numeric Check )
        if (model.Password.Length < 8)
        {
            ViewBag.ErrorMessage = "Password Must be at Least 8 Characters";
            return View("Signup");
        }

        var containsDigit = model.Password.Any(char.IsDigit);
        var containAlpha = model.Password.Any(char.IsLetter);

        if (!containsDigit || !containAlpha)
        {
            ViewBag.ErrorMessage = "Password Must Contain Alpha-Numeric Characters";
            return View("Signup");
        }

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password); // Hashing the password

        await using (var connection = new MySqlConnection(connectionString)) // Connection Initialization
        {
            const string checkQuery = "SELECT * FROM users WHERE email = @Email"; // Email Uniqueness Check Query

            var existingUser =
                await connection.QuerySingleOrDefaultAsync<User>(checkQuery, new { model.Email }); // Execution

            if (existingUser != null)
            {
                ViewBag.ErrorMessage = "Email Already Exists, Try Again with a New Email Address";
                return View("Signup");
            }

            //Insert Query for New User
            const string userQuery =
                "INSERT INTO users (firstname, lastname, email, password_hash) VALUES (@FirstName, @LastName, @Email, @Password_Hash)";

            var userParameters = new
            {
                model.FirstName,
                model.LastName,
                model.Email,
                Password_Hash = hashedPassword
            };

            try
            {
                await connection.ExecuteAsync(userQuery, userParameters); // Create a User

                // Get the newly created user's ID
                const string userIdQuery = "SELECT LAST_INSERT_ID()";
                var userId = await connection.QuerySingleAsync<int>(userIdQuery);

                const string profileQuery =
                    "INSERT INTO user_profiles (User_Id, Address, City, State, Postal_Code, Phone, Country) VALUES (@UserId, @Address, @City, @State, @PostalCode, @Phone, @Country)";
                var profileParameters = new
                {
                    UserId = userId,
                    model.Address,
                    model.City,
                    model.State,
                    PostalCode = model.Postal_Code,
                    model.Phone,
                    model.Country
                };

                await connection.ExecuteAsync(profileQuery, profileParameters);

                ViewBag.Message = "User Registered Successfully";
                return RedirectToAction("Login", "Login");
            }
            catch (MySqlException ex)
            {
                ViewBag.ErrorMessage = "Error: " + ex.Message;
            }
        }

        return View("Signup");
    }
}