using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
using SkillSwapCore;
using SkillSwapServices.Interfaces;
using SkillSwapServices.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro dos serviços
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<ITransactionService, TransactionService>(); 


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
