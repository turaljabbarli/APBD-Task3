using ConsoleApp1.Logic; // Add your actual namespace here

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddControllers();

// Register your existing device manager logic (Singleton since it manages state in memory)
builder.Services.AddSingleton<DeviceManager>();

// Swagger setup (for API testing in browser)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use Swagger only in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Enables routing via [ApiController]

app.Run();