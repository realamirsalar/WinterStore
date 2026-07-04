using WinterStore.Application;
using WinterStore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();
