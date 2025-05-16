using MediatR;
using CleanArc.Domain.Shared.Results;

namespace CleanArc.Application.Shared.UseCases.Abstractions;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
    where TResponse : IQueryResponse
{
}