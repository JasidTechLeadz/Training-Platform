using IdentityManagement.API.Interfaces;
using IdentityManagement.API.Repositories;
using IdentityManagement.API.Services;


var builder = WebApplication.CreateBuilder(args);


// Add Controllers
builder.Services.AddControllers();


// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Dependency Injection

builder.Services.AddSingleton<IUserRepository, UserRepository>();

builder.Services.AddSingleton<UserService>();

// Dapr
builder.Services.AddDaprClient();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();


app.Run();