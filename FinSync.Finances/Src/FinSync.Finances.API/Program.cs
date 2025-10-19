using FinSync.Finances.API.Config;
using FinSync.Finances.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);

builder.Services.AddGrpc(options =>
{
  options.EnableDetailedErrors = true;
});

builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

builder.InjectDbContext();
builder.InjectDesignatedDependencies();
builder.InjectObjectMapper();

var app = builder.Build();

app.MapGrpcService<FinancialAccountGRPCService>();
app.MapGrpcReflectionService();

app.Run();