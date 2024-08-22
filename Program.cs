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
builder.Services.ConfigureDbStore(builder.Configuration);
builder.Services.ConfigureRepository();
builder.Services.ConfigureService();


var app = builder.Build();
var logger=app.Services.GetService<ILogger>();
app.ConfigureGlobalExceptionHandler(logger!);
// app.ConfigureMiddleware(logger!);

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

app.UseAuthorization();

app.MapControllers();

app.Run();
