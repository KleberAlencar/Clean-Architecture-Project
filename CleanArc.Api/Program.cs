using MediatR;
using CleanArc.Application;
using CleanArc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using CleanArc.Infrastructure.Shared.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

//TODO: Change connection string to other local.
var connectionString = "Server=localhost,1433;Database=DB_Clean_Architecture;User Id=sa;Password=;Trusted_Connection=False; TrustServerCertificate=True;";

builder.Services.AddDbContext<AppDbContext>(x =>
    x.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning))
    .UseSqlServer(connectionString, m => m.MigrationsAssembly("CleanArc.Api")));
builder.Services.AddAccountApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.MapPost("/v1/students", async (
    ISender sender,
    CleanArc.Application.Accounts.UseCases.Create.Command command) =>
{
    var result = await sender.Send(command);
    return TypedResults.Created($"v1/students/{result.Value.Id}", result);
});

app.Run();
