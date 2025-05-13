using CleanArc.Domain.Shared.Aggregates.Abstractions;

namespace CleanArc.Domain.Shared.Repositories.Abstractions;

public interface IRepository<TEntity> where TEntity : IAggregateRoot;