using Microsoft.EntityFrameworkCore;
using CleanArc.Domain.Accounts.Entities;
using CleanArc.Infrastructure.Shared.Data;
using CleanArc.Application.Accounts.Repositories.Abstractions;

namespace CleanArc.Infrastructure.Accounts.Repositories;

public class AccountRepository(AppDbContext context) : IAccountRepository
{
    public async Task<bool> VerifyNameExistsAsync(string firstName, string lastName) 
        => await context.Students.AsNoTracking().AnyAsync(
            x => $"{x.Name.FirstName} {x.Name.LastName}" == $"{firstName} {lastName}");    
    
    public async Task<bool> VerifyEmailExistsAsync(string email) 
        => await context.Students.AsNoTracking().AnyAsync(x => x.Email.Address == email);

    public async Task SaveAsync(Student student) 
        => await context.Students.AddAsync(student);

    public async Task<Student?> GetByIdAsync(Guid id)
    {
        return await context.Students.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
    }
}