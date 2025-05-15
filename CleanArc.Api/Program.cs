using MediatR;
using CleanArc.Application;
using CleanArc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using CleanArc.Infrastructure.Shared.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Server=localhost,1433;Database=Clean_Architecture_DB;User Id=sa;Password=170421sqSE@;Trusted_Connection=False; TrustServerCertificate=True;";
builder.Services.AddDbContext<AppDbContext>(x => 
    x.UseSqlServer(connectionString, m => m.MigrationsAssembly("CleanArc.Api")));
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
