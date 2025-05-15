namespace CleanArc.Application.Shared.Repositories.Abstractions;

public interface IUnitOfWork
{
    Task CommitAsync();
    Task RollbackAsync();
}