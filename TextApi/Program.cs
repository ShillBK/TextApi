var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => Results.Ok(new
{
    name = "Text API",
    version = "1.0",
    endpoints = new[] { "/api/text/uppercase" }
}));

app.MapPost("/api/text/uppercase", (UppercaseRequest req) =>
{
    if (string.IsNullOrEmpty(req.text))
        return Results.BadRequest(new { error = "text is required" });

    return Results.Ok(new
    {
        original = req.text,
        uppercased = req.text.ToUpper()
    });
});

app.Run();

record UppercaseRequest(string text);
