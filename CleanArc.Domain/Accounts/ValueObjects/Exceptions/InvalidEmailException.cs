using CleanArc.Domain.Shared.Exceptions;

namespace CleanArc.Domain.Accounts.ValueObjects.Exceptions;

public sealed class InvalidEmailException(string message)
    : DomainException(message);