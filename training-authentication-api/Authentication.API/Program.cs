using Utilities.Configuration;
using Authentication.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var jwtSettings =
    builder.Configuration
    .GetSection("JwtSettings")
    .Get<JwtSettings>()
    ?? throw new Exception("JWT settings are missing");

Console.WriteLine(
    $"JWT Secret Length: {jwtSettings.Secret.Length}"
);

// Add Controllers
builder.Services.AddControllers();


// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Dependency Injection

// JWT Token generation service
builder.Services.AddSingleton(jwtSettings);

builder.Services.AddSingleton<TokenService>();
builder.Services
.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters =
        new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,

            IssuerSigningKey =
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    jwtSettings.Secret
                )),

            ValidateIssuer = false,

            ValidateAudience = false
        };
});

// Dapr Client
builder.Services.AddDaprClient();



var app = builder.Build();


// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// HTTPS
// Keep commented for local Dapr testing
// app.UseHttpsRedirection();


// Map Controllers
app.MapControllers();


app.Run();