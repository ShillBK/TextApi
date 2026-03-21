var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger middleware
app.UseSwagger();
app.UseSwaggerUI();

// Root endpoint
app.MapGet("/", () => Results.Ok(new
{
    name = "Text API",
    version = "1.0",
    endpoints = new[]
    {
        "/api/text/uppercase"
    }
}));

// API endpoint
app.MapPost("/api/text/uppercase", (dynamic req) =>
{
    string input = req.inputText;

    return Results.Ok(new
    {
        original = input,
        uppercased = input.ToUpper()
    });
});

app.Run();
