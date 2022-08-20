using Infra.Crosscutting.;
using Infra.Crosscutting.Identity.IdentityConfigurations;
using MediatR;
using NetDevPack.Identity;
using NetDevPack.Identity.User;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings{builder.Environment.EnvironmentName}.json.", true, true)
    .AddEnvironmentVariables();


//ConfigureServices

// WebAPI Config
builder.Services.AddControllers();

// Setting DBContexts
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// ASP.NET Identity Settings & JWT
builder.Services.AddApiIdentityConfiguration(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
