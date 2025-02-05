using Samurai.DAL.Interfaces;
using Samurai.DAL.Models;
using Samurai.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var conStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(obj => obj.UseSqlServer(conStr));

builder.Services.AddScoped<IBattle, BattleRepository>();
builder.Services.AddScoped<ISamurai, SamuraiRepository>();
builder.Services.AddScoped<IHorse, HorseRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Samurai API"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();