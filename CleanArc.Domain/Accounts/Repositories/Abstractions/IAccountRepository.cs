using CleanArc.Domain.Accounts.Entities;
using CleanArc.Domain.Shared.Repositories.Abstractions;

namespace CleanArc.Domain.Accounts.Repositories.Abstractions;

public interface IAccountRepository : IRepository<Student>
{
    Task CreateAsync(Student student, CancellationToken cancellationToken = default);
}