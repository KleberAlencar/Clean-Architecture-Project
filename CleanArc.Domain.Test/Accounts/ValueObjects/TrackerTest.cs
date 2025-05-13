using CleanArc.Domain.Test.Mocks;
using CleanArc.Domain.Shared.Abstractions;
using CleanArc.Domain.Accounts.ValueObjects;

namespace CleanArc.Domain.Test.Accounts.ValueObjects;

public class TrackerTest
{
    private readonly IDateTimeProvider _dateTimeProvider = new FakeDateTimeProvider();
    
    [Fact]
    public void Should_Create_New_Tracker_With_Current_Utc_Date()
    {
        var tracker = Tracker.Create(_dateTimeProvider);
        Assert.Equal(_dateTimeProvider.UtcNow, tracker.CreatedAtUtc);;
    }
}