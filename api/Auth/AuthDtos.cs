namespace Api.Auth;

public record LoginRequest(string Username, string Password);
public record LoginResponse(string Username); 

// move to common folder later
public record ApiError(string Code, string Message);