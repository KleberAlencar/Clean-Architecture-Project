using CleanArc.Domain.Shared.Exceptions;

namespace CleanArc.Domain.Accounts.ValueObjects.Exceptions;

public sealed class InvalidLastNameLengthException(string message)
    : DomainException(message);