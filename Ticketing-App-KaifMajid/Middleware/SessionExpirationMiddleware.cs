using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using Dapper;
using MySql.Data.MySqlClient;

namespace WebApplication1.Middleware;

public class SessionExpirationMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var sessionId = context.Session.GetInt32("user_session_id");
        if (sessionId.HasValue)
        {
            // Retrieve the session expiration time as a string
            var sessionExpiresAtString = context.Session.GetString("SessionExpiresAt");

            if (DateTime.TryParse(sessionExpiresAtString, CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out var sessionExpiresAt))
                // Check if the session has expired
                if (sessionExpiresAt <= DateTime.UtcNow)
                {
                    // If expired, update the logout time in the database, clear the session
                    await UpdateLogoutTime(context, sessionId.Value);
                    context.Session.Clear();
                    context.Response.Redirect("/"); // Redirect to login on token expiration
                    return;
                }

            // Check JWT Token expiration
            var token = context.Session.GetString("accessToken");
            if (!string.IsNullOrEmpty(token))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);
                var expirationTime = jwtToken?.ValidTo;

                if (expirationTime.HasValue && expirationTime.Value <= DateTime.UtcNow)
                {
                    // Token expired, clear session and redirect to login
                    await UpdateLogoutTime(context, sessionId.Value);
                    context.Session.Clear();
                    context.Response.Redirect("/"); // Redirect to login on token expiration
                    return;
                }
            }
        }

        await next(context);
    }

    private static async Task UpdateLogoutTime(HttpContext context, int sessionId)
    {
        const string connectionString = "Server=localhost;Database=test;User=root;Password=Mohid123;";

        await using var connection = new MySqlConnection(connectionString);

        const string updateQuery = "UPDATE User_Sessions SET is_active = @IsActive WHERE session_id = @SessionId";
        var parameters = new
        {
            IsActive = false,
            SessionId = sessionId
        };

        await connection.ExecuteAsync(updateQuery, parameters);
    }
}