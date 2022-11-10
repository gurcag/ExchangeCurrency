using CurrencyExchange.Services.CurrencyRate.API.Repositories;
using CurrencyExchange.Services.CurrencyRate.API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

IConfiguration configuration = builder.Configuration;
var multiplexer = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);
builder.Services.AddScoped<ISymbolService, SymbolService>()
                .AddScoped<ICurrencyRateService, CurrencyRateService>()
                .AddScoped<ICacheRepository, RedisCacheRepository>()
                .AddScoped<ISymbolRepository, SymbolRepository>()
                .AddScoped<ICurrenyRateRepository, ICurrenyRateRepository>()
                .AddScoped<ICurrencyRateService, CurrencyRateService>()
                .AddScoped<ICurrencyRateService, CurrencyRateService>()
                .AddScoped<ICurrencyRateService, CurrencyRateService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();