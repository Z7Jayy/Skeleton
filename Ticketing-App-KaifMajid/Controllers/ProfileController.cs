using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Authorize]
public class ProfileController : Controller
{
    private const string ConnectionString = "Server=localhost;Database=test;User=root;Password=;";
    private static UserProfileViewModel _userProfile = new();


    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        var userId = HttpContext.Session.GetInt32("userId");

        if (userId == null)
            return RedirectToAction("Login", "Login");


        await using var connection = new MySqlConnection(ConnectionString);

        const string query =
            "SELECT * FROM users u JOIN user_profiles p ON u.userId = p.user_id WHERE  u.userId = @UserId";

        var userProfile =
            await connection.QueryFirstOrDefaultAsync<UserProfileViewModel>(query, new { UserId = userId });

        if (userProfile == null)
            return RedirectToAction("Login", "Login");

        _userProfile = userProfile;

        return View(_userProfile);
    }


    [HttpPost]
    public async Task<IActionResult> UpdateProfile([FromForm] UserProfileViewModel updatedProfile)
    {
        var userId = HttpContext.Session.GetInt32("userId");

        if (userId == null)
            return RedirectToAction("Login", "Login");

        if (updatedProfile.FirstName.IsNullOrEmpty() || updatedProfile.LastName.IsNullOrEmpty() ||
            updatedProfile.Address.IsNullOrEmpty() ||
            updatedProfile.Postal_Code.IsNullOrEmpty() || updatedProfile.City.IsNullOrEmpty() ||
            updatedProfile.Email.IsNullOrEmpty() || updatedProfile.State.IsNullOrEmpty() ||
            updatedProfile.Country.IsNullOrEmpty() || updatedProfile.Phone.IsNullOrEmpty())
        {
            ViewBag.ErrorMessage = "All Fields are Mandatory !";
            return View("Profile", _userProfile);
        }

        var hashedPassword = "";
        var passUpdated = false;

        if (!updatedProfile.Password.IsNullOrEmpty())
        {
            if (updatedProfile.Password.Trim().Length < 8)
            {
                ViewBag.ErrorMessage = "Password Must be at Least 8 Characters";
                return View("Profile", _userProfile);
            }

            var containsDigit = updatedProfile.Password.Any(char.IsDigit);
            var containAlpha = updatedProfile.Password.Any(char.IsLetter);

            if (!containsDigit || !containAlpha)
            {
                ViewBag.ErrorMessage = "Password Must Contain Alpha-Numeric Characters";
                return View("Profile", _userProfile);
            }

            hashedPassword = BCrypt.Net.BCrypt.HashPassword(updatedProfile.Password.Trim()); // Hashing the password
            passUpdated = true;
        }


        await using var connection = new MySqlConnection(ConnectionString);

        const string query = @"
            UPDATE users 
            SET firstname = @FirstName, lastname = @LastName, email = @Email ,password_hash = @Password_Hash
            WHERE userId = @UserId;
            
            UPDATE user_profiles 
            SET address = @Address, city = @City, state = @State, postal_Code = @PostalCode, 
                phone = @Phone, country = @Country 
            WHERE user_id = @UserId";

        var parameters = new
        {
            updatedProfile.FirstName,
            updatedProfile.LastName,
            updatedProfile.Email,
            Password_Hash = passUpdated
                ? hashedPassword
                : updatedProfile.Password_Hash,

            updatedProfile.Address,
            updatedProfile.City,
            updatedProfile.State,
            PostalCode = updatedProfile.Postal_Code,
            updatedProfile.Phone,
            updatedProfile.Country,
            UserId = userId
        };
        try
        {
            await connection.ExecuteAsync(query, parameters);
            ViewBag.Message = "Profile updated successfully.";

            _userProfile = updatedProfile;
        }
        catch
            (MySqlException ex)
        {
            ViewBag.ErrorMessage = "Error: " + ex.Message;
        }

        return View("Profile", _userProfile);
    }
}