using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestApi.Repositories.Interfaces; // ITodoRepository
using RestApi.Repositories.Implementations; // TodoRepository
using RestApi.Services.Interfaces; 
using RestApi.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Load environment-specific configuration
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Configure database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext") 
        ?? throw new InvalidOperationException("Connection string 'ApplicationDbContext' not found.")));

// Enable CORS globally
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200", "https://white-rock-0f754d01e.6.azurestaticapps.net") 
                  .AllowAnyHeader()
                  .AllowAnyMethod();  
        });
});

builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ITodoService, TodoService>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use CORS policy
app.UseCors("AllowAngularApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    Console.WriteLine("Running in Development mode - Using Development Configuration");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
