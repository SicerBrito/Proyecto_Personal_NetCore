using API.Extensions;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using AspNetCoreRateLimit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureRateLimiting();
// builder.Services.ConfigureApiVersioning();
builder.Services.ConfigureCors();
builder.Services.AddAplicacionServices();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<PaginaContext>(options =>
{
    string ? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseRateLimiter();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
