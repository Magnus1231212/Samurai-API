using Samurai.DAL.Interfaces;
using Samurai.DAL.Models;
using Samurai.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddControllers();

var conStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(obj => obj.UseSqlServer(conStr));

builder.Services.AddScoped<IBattle, BattleRepository>();
builder.Services.AddScoped<ISamurai, SamuraiRepository>();
<<<<<<< HEAD
builder.Services.AddScoped<IBattle, BattleRepository>();
builder.Services.AddScoped<IHorse, HorseRepository>();

using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    if (dbContext.Database.CanConnect())
    {
        Console.WriteLine("Database connected successfully");
    }
    else
    {
        Console.WriteLine("Database connection failed");
    }
}
=======
builder.Services.AddScoped<IHorse, HorseRepository>();

>>>>>>> bb7830fab4e2cb8f9dfa189071e7acee1ff5dc49

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Samurai API"));
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();