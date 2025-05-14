using CleanArc.Domain.Shared.Abstractions;

namespace CleanArc.Domain.Shared.Common;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow { get; } = DateTime.UtcNow;
}