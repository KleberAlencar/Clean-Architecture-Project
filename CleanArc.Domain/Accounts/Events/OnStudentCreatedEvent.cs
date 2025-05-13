using CleanArc.Domain.Shared.Events.Abstractions;

namespace CleanArc.Domain.Accounts.Events;

public sealed record OnStudentCreatedEvent(Guid Id, string Name, string Email) : IDomainEvent;