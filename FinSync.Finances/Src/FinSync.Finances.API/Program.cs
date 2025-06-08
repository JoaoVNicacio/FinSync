using FinSync.Finances.Infra;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext<FinancesDBContext>(options => 
  options.UseNpgsql(Environment.GetEnvironmentVariable("FINANCES_DB_CONNECTION_STRING")));

var app = builder.Build();

app.Run();