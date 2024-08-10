using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

public class TokenMiddleware
{
    private readonly RequestDelegate _next;

    public TokenMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.Value;

        if (path != null &&
            !path.StartsWith("/login", StringComparison.OrdinalIgnoreCase) &&
            !path.Equals("/", StringComparison.OrdinalIgnoreCase))
        {
            var token = context.Session.GetString("accessToken");

            var userEmail = context.Session.GetString("email");

            var tokenHandler = new JwtSecurityTokenHandler();

            if (tokenHandler.CanReadToken(token))
            {
                // Parse the token
                var jwtToken = tokenHandler.ReadJwtToken(token);

                // Extract claims
                var claims = jwtToken.Claims;


                var emailClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

                if (userEmail != null && !string.IsNullOrEmpty(token) && userEmail.Equals(emailClaim))
                    context.Request.Headers.Authorization = "Bearer " + token;
            }
        }

        await _next(context);
    }
}