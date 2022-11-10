using Ocelot.DependencyInjection;
using Ocelot.Middleware;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("ocelot.json")
                            .Build();

builder.Services.AddOcelot(configuration);


var app = builder.Build();

app.UseHttpsRedirection();

app.UseOcelot().Wait();

app.UseAuthorization();

app.MapControllers();

app.Run();