namespace CleanArc.Domain.Shared.Results;

public record Error(string Code, string Message)
{
    public static Error None = new(string.Empty, string.Empty);
    public static Error NullValue = new("Error.NullValue", "A Null value was provided.");
    public static Error InvalidValue = new("Error.InvalidValue", "A Invalid value was provided.");
    public static Error NotFound = new("Error.NotFound", "A resource was not found.");
}