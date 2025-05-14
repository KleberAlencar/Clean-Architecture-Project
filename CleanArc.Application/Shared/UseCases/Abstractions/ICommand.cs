using MediatR;
using CleanArc.Domain.Shared.Results;

namespace CleanArc.Application.Shared.UseCases.Abstractions;

public interface ICommand : IRequest<Result>;

public interface ICommand<TCommandResponse> : IRequest<Result<TCommandResponse>> 
    where TCommandResponse : ICommandResponse;