using System.Text.Json;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Versta.OrderPlacement.Data;
using Versta.OrderPlacement.Application;
using Versta.OrderPlacement.Data.Engine;
using Versta.OrderPlacement.Web;
using Versta.OrderPlacement.Web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddValidatorsFromAssemblyContaining(typeof(IWebMarker));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(IAppMarker));

builder.Services.AddData();
builder.Services.AddApplication();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    );
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenApi();

builder.Services.AddCors();

builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.UseExceptionHandler(opt => { });

app.MapOpenApi();

app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    context.Database.Migrate();
}

app.MapHealthChecks("/healthcheck");

app.Run();
