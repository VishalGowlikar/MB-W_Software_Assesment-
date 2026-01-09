using Microsoft.OpenApi.Models;
using TaskManagementAPI.Repositories;
using TaskManagementAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Add Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Task Management API",
        Version = "v1",
        Description = "A simple RESTful API for managing tasks"
    });
});

// Dependency Injection (DI) for repository and service
builder.Services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();
builder.Services.AddTransient<TaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task Management API v1");
        c.RoutePrefix = string.Empty; // Swagger at root: https://localhost:5001/
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
