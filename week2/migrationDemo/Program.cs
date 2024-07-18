using Microsoft.EntityFrameworkCore;
using migrationDemo.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["ConnectionString"];

builder.Services.AddDbContext<DemoContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
