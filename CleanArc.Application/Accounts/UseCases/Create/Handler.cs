using CleanArc.Domain.Shared.Results;
using CleanArc.Application.Shared.UseCases.Abstractions;

namespace CleanArc.Application.Accounts.UseCases.Create;

public sealed class Handler() : ICommandHandler<Command, Response>
{
    public Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        // Verifica se o e-mail ja esta cadastrado
        
        // Gera os VOs
        
        // Gera a entidade
        
        // Persiste os dados
        
        // Retorna a resposta
        
        throw new NotImplementedException();
    }
}