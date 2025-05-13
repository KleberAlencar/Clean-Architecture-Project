using CleanArc.Domain.Shared.Abstractions;

namespace CleanArc.Domain.Test.Mocks;

public class FakeDateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow { get; } = new DateTime(2022, 01, 01, 00, 00, 00, DateTimeKind.Utc);
}