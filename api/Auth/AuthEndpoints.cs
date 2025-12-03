namespace Api.Auth;

public static class AuthEndpoints
{
    public static RouteGroupBuilder MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var auth = app.MapGroup("/auth").WithTags("Auth");

        auth.MapPost("/login", Login);
        return auth;
    }

    private static IResult Login(LoginRequest req)
    {
        if (string.IsNullOrWhiteSpace(req.Username) || string.IsNullOrWhiteSpace(req.Password))
        {
            return Results.BadRequest(new ApiError(
                Code: "missing_credentials",
                Message: "Username and password are required."
            ));
        }

        // Temporary fake login check (replace later with DB lookup)
        if (req.Username != "test" || req.Password != "secret")
        {
            return Results.Json(
                new ApiError("invalid_credentials","Invalid username or password."),
                statusCode: StatusCodes.Status401Unauthorized
            );
        }

        return Results.Ok(new LoginResponse(req.Username));
    }
}