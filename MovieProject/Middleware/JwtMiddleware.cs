using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


namespace MovieProject.Middleware
{
    public class JwtDebugMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<JwtDebugMiddleware> _logger;

        public JwtDebugMiddleware(RequestDelegate next, ILogger<JwtDebugMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log incoming request info
            _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");

            // Check for Authorization header
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
                if (authHeader?.StartsWith("Bearer ") == true)
                {
                    var token = authHeader.Substring("Bearer ".Length).Trim();
                    _logger.LogInformation($"Bearer token present, length: {token.Length}");

                    // Basic token validation check
                    if (string.IsNullOrEmpty(token))
                    {
                        _logger.LogWarning("Empty bearer token provided");
                    }
                }
                else
                {
                    _logger.LogWarning($"Authorization header present but not Bearer: {authHeader}");
                }
            }
            else
            {
                _logger.LogInformation("No Authorization header present");
            }

            // Continue to next middleware
            await _next(context);

            // Log authentication results after processing
            if (context.User?.Identity?.IsAuthenticated == true)
            {
                _logger.LogInformation($"User authenticated: {context.User.Identity.Name}");
                _logger.LogInformation($"Authentication type: {context.User.Identity.AuthenticationType}");

                // Log claims
                foreach (var claim in context.User.Claims.Take(5)) // Limit to first 5 claims
                {
                    _logger.LogInformation($"Claim: {claim.Type} = {claim.Value}");
                }
            }
            else
            {
                _logger.LogWarning("User not authenticated after processing");
            }

            _logger.LogInformation($"Response status: {context.Response.StatusCode}");
        }
    }
}
