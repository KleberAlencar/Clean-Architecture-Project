using CleanArc.Application.Shared.UseCases.Abstractions;

namespace CleanArc.Application.Accounts.UseCases.Get;

public record Response(Guid Id, string Name, string Email) : IQueryResponse;