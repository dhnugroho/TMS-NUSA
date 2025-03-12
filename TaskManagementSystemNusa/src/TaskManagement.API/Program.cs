using TaskManagement.Application.Services;
using TaskManagement.Domain.Repositories;
using TaskManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Register dependencies
builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<TaskService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
//dotnet run --project src/TaskManagement.API --urls "https://localhost:5001;http://localhost:5000"