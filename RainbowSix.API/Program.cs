using Microsoft.EntityFrameworkCore;
using RainbowSix.Common.Database.Entities;
using RainbowSix.Common.Interfaces;
using RainbowSix.ConsoleApp;
using RainbowSix.WebClient.Interfaces;
using RainbowSix.Common.Database;
using RainbowSix.Common.Database.Services;
using RainbowSix.Common.Database.Mappers;

var builder = WebApplication.CreateBuilder(args);

// dependency injection registration
builder.Services.AddScoped<IHttpConnectionLogger, ConnectionLogger>();
builder.Services.AddScoped<IUbisoftSessionStore, UbisoftSessionDbStore>();
builder.Services.AddScoped<IRainbowSixMarketService, RainbowSixMarketService>();
builder.Services.AddScoped<IMappingService, MappingService>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RainbowSixDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
