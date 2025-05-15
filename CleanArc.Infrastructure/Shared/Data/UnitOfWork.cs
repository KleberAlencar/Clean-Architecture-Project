using CleanArc.Application.Shared.Repositories.Abstractions;

namespace CleanArc.Infrastructure.Shared.Data;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CommitAsync() => await context.SaveChangesAsync();

    public Task RollbackAsync() => Task.CompletedTask;
}