using Microsoft.EntityFrameworkCore;
using CleanArc.Domain.Accounts.Entities;
using CleanArc.Infrastructure.Shared.Data;
using CleanArc.Application.Accounts.Repositories.Abstractions;

namespace CleanArc.Infrastructure.Accounts.Repositories;

public class AccountRepository(AppDbContext context) : IAccountRepository
{
    public async Task<bool> VerifyNameExistsAsync(string firstName, string lastName) 
        => await context.Students.AsNoTracking().AnyAsync(x => x.Name == $"{firstName} {lastName}");    
    
    public async Task<bool> VerifyEmailExistsAsync(string email) 
        => await context.Students.AsNoTracking().AnyAsync(x => x.Email == email);

    public async Task SaveAsync(Student student) 
        => await context.Students.AddAsync(student);
}