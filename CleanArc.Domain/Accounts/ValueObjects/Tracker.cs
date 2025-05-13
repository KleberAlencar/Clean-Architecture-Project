using CleanArc.Domain.Shared.Abstractions;
using CleanArc.Domain.Shared.ValueObjects;

namespace CleanArc.Domain.Accounts.ValueObjects;

public sealed record Tracker : ValueObject
{
    #region [ Constructors ]

    private Tracker(DateTime createdAtUtc, DateTime updatedAtUtc)
    {
        CreatedAtUtc = createdAtUtc;
        UpdatedAtUtc = updatedAtUtc;       
    }

    #endregion
    
    #region [ Factory Methods ]

    public static Tracker Create(IDateTimeProvider dateTimeProvider) => new(dateTimeProvider.UtcNow, dateTimeProvider.UtcNow);
    
    public static Tracker Create(DateTime createdAtUtc, DateTime updatedAtUtc) => new(createdAtUtc, updatedAtUtc);
    
    #endregion
    
    #region [ Properties ]

    public DateTime CreatedAtUtc { get; }
    
    public DateTime UpdatedAtUtc { get; private set; }
    
    #endregion

    #region [ Public Methods ]

    public void Update(IDateTimeProvider dateTimeProvider) => UpdatedAtUtc = dateTimeProvider.UtcNow;       

    #endregion
}