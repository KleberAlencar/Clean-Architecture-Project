using CleanArc.Domain.Shared.Aggregates.Abstractions;

namespace CleanArc.Application.Shared.Repositories.Abstractions;

public interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot;
