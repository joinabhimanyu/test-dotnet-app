using AutoMapper;
using Microsoft.EntityFrameworkCore;
using test_dotnet_app.DbStore;
using test_dotnet_app.Extensions;
using test_dotnet_app.Middlewares;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.ConfigureDbStore(builder.Configuration);
builder.Services.ConfigureRepository();
builder.Services.ConfigureService();
// builder.Services.AddAutoMapper(typeof(Program));
builder.Services.RegiserRequestCultureMiddleware();
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);


var app = builder.Build();

app.ConfigureGlobalExceptionHandler();
app.ConfigureMiddleware();
app.UseRequestCultureMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
