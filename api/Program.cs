using Api.Data;
using Microsoft.EntityFrameworkCore;
using Api.Auth;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "API is running");

app.MapGet("/test", (HttpRequest request) =>
{
    var cookies = string.Join("; ", request.Cookies.Select(kvp => $"{kvp.Key}={kvp.Value}"));
    Console.WriteLine($"[GET /test] Cookies received: {cookies}");

    return Results.Ok(new
    {
        method = "GET",
        cookies = request.Cookies
    });
});

app.MapPost("/test", (HttpRequest request) =>
{
    var cookies = string.Join("; ", request.Cookies.Select(kvp => $"{kvp.Key}={kvp.Value}"));
    Console.WriteLine($"[POST /test] Cookies received: {cookies}");

    return Results.Ok(new
    {
        method = "POST",
        cookies = request.Cookies
    });
});

app.MapGet("/db-test", async (AppDbContext db) =>
{
    var canConnect = await db.Database.CanConnectAsync();
    return Results.Ok(new { db = canConnect ? "ok" : "failed" });
});

app.MapAuthEndpoints();

app.Run();
