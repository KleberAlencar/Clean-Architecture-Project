using CleanArc.Domain.Shared.ValueObjects;
using CleanArc.Domain.Accounts.ValueObjects.Exceptions;

namespace CleanArc.Domain.Accounts.ValueObjects;

public sealed record Name : ValueObject
{
    #region [ Constants ]

    public const int MinLength = 3;
    public const int MaxLength = 60;

    #endregion
    
    #region [ Constructors ]
    
    private Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    #endregion

    #region [ Factory Methods ]

    public static Name Create(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) ||
            string.IsNullOrWhiteSpace(lastName) ||
            string.IsNullOrWhiteSpace(firstName) || 
            string.IsNullOrWhiteSpace(lastName))
        {
            throw new InvalidNameException("Name must not be empty.");       
        }
        
        if (firstName.Length < MinLength)
            throw new InvalidFirstNameLengthException($"First name must have at least {MinLength} characters.");
        
        if (firstName.Length > MaxLength)
            throw new InvalidFirstNameLengthException($"First name must be less than {MaxLength} characters.");        
        
        if (lastName.Length < MinLength)
            throw new InvalidLastNameLengthException($"Last name must have at least {MinLength} characters.");
        
        if (lastName.Length > MaxLength)
            throw new InvalidLastNameLengthException($"Last name must be less than {MaxLength} characters");          
        
        return new Name(firstName, lastName);
    }
    
    #endregion
    
    #region [ Properties ]

    public string FirstName { get; }

    public string LastName { get; }

    #endregion

    #region [ Operators ]

    public static implicit operator string(Name name) => name.ToString();

    #endregion

    #region [ Overrides ]

    public override string ToString() => $"{FirstName} {LastName}";
    
    #endregion
}