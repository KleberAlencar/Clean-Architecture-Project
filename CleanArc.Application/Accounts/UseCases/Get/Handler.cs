using CleanArc.Domain.Shared.Results;
using CleanArc.Application.Shared.UseCases.Abstractions;
using CleanArc.Application.Accounts.Repositories.Abstractions;

namespace CleanArc.Application.Accounts.UseCases.Get;

public class Handler(IAccountRepository repository) : IQueryHandler<Query, Response>
{
    public async Task<Result<Response>> Handle(Query request, CancellationToken cancellationToken)
    {
        var student = await repository.GetByIdAsync(request.Id);
        if (student is null)
            return Result.Failure<Response>(new Error("404", "Student not found"));
        
        return Result.Success(new Response(student.Id, student.Name.ToString(), student.Email.Address));
    }
}