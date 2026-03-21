var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Always enable Swagger
app.UseSwagger();
app.UseSwaggerUI();

// ❌ Remove HTTPS redirection
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
