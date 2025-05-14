using CleanArc.Application.Shared.UseCases.Abstractions;

namespace CleanArc.Application.Accounts.UseCases.Create;

public sealed record Response(Guid Id, string Name, string Email) : ICommandResponse;