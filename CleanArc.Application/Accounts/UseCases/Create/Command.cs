using CleanArc.Application.Shared.UseCases.Abstractions;

namespace CleanArc.Application.Accounts.UseCases.Create;

public sealed record Command(string FirstName, string LastName, string Email) : ICommand<Response>;