using BSEB_API2026.Controllers;
using BSEB_API2026.Data;
using BSEB_API2026.Middleware;
using BSEB_API2026.Services; // ✅ Add this
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext registration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));

// Service registration for DI
builder.Services.AddScoped<IDwnldRegFormService, DwnldRegFormService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<_InterRegistrationFormService, InterRegistrationFormService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware pipeline (error handler first)
app.UseMiddleware<ErrorHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
