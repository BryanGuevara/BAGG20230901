using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ReturnUrlParameter = "unauthorized";
        options.Events = new CookieAuthenticationEvents {

            OnRedirectToLogin = context =>
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                context.Response.ContentType = "application/json";
                var message = new
                {
                    error = "No Autorizado",
                    message = "Debe iniciar sesión para acceder a este recurso"
                };
                var jsonMessage = JsonSerializer.Serialize(message);
                return context.Response.WriteAsJsonAsync(jsonMessage);
            }
        };
    });
 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
