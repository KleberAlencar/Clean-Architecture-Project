using CleanArc.Domain.Shared.Exceptions;

namespace CleanArc.Domain.Accounts.ValueObjects.Exceptions;

public sealed class InvalidEmailLengthException(string message)
    : DomainException(message);