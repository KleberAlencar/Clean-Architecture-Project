using CleanArc.Domain.Shared.Exceptions;

namespace CleanArc.Domain.Accounts.ValueObjects.Exceptions;

public class InvalidNameException(string message) : DomainException(message);