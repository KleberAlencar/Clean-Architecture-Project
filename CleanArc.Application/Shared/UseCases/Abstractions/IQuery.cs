using MediatR;
using CleanArc.Domain.Shared.Results;

namespace CleanArc.Application.Shared.UseCases.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> where TResponse : IQueryResponse;