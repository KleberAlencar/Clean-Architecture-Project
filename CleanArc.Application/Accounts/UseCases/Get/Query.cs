using CleanArc.Application.Shared.UseCases.Abstractions;

namespace CleanArc.Application.Accounts.UseCases.Get;

public record Query(Guid Id) : IQuery<Response>;