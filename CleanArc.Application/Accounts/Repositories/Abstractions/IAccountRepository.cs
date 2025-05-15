using CleanArc.Domain.Accounts.Entities;
using CleanArc.Application.Shared.Repositories.Abstractions;

namespace CleanArc.Application.Accounts.Repositories.Abstractions;

public interface IAccountRepository : IRepository<Student>
{
    Task<bool> VerifyNameExistsAsync(string firstName, string lastName);
    
    Task<bool> VerifyEmailExistsAsync(string email);
    
    Task SaveAsync(Student student);
}