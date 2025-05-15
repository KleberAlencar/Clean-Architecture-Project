using CleanArc.Domain.Shared.Common;
using CleanArc.Domain.Shared.Results;
using CleanArc.Domain.Accounts.Entities;
using CleanArc.Domain.Accounts.ValueObjects;
using CleanArc.Domain.Accounts.ValueObjects.Exceptions;
using CleanArc.Application.Shared.UseCases.Abstractions;
using CleanArc.Application.Shared.Repositories.Abstractions;
using CleanArc.Application.Accounts.Repositories.Abstractions;

namespace CleanArc.Application.Accounts.UseCases.Create;

public sealed class Handler(
    IAccountRepository accountRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<Command, Response>
{
    
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var nameExists = await accountRepository.VerifyNameExistsAsync(request.FirstName, request.LastName);
        if (nameExists) return Result.Failure<Response>(new Error("400", ErrorMessage.Name.NameExists));
        
        var emailExists = await accountRepository.VerifyEmailExistsAsync(request.Email);
        if (emailExists) return Result.Failure<Response>(new Error("400", ErrorMessage.Email.EmailExists));
        
        var name = Name.Create(request.FirstName, request.LastName);
        var email = Email.Create(request.Email);
        
        var student = Student.Create(name, email, new DateTimeProvider());
        
        await accountRepository.SaveAsync(student);
        await unitOfWork.CommitAsync();       
        
        var response = new Response(student.Id, student.Name, student.Email);
        return Result.Success(response);
    }
    
}