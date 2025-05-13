using CleanArc.Domain.Shared.Exceptions;

namespace CleanArc.Domain.Accounts.ValueObjects.Exceptions;

public sealed class InvalidFirstNameLengthException(string message) 
    : DomainException(message);