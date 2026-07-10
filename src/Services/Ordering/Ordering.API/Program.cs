using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

var app = builder.Build();

app.UseApiServices();

if(app.Environment.IsDevelopment())
{
   await app.InitialiseDatabaseAsync();
}

// Configure the HTTP request pipeline.
//app.MapGet("/", () => "Hello World!");

app.Run();
