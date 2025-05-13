using System.Text.RegularExpressions;
using CleanArc.Domain.Shared.ValueObjects;
using CleanArc.Domain.Accounts.ValueObjects.Exceptions;

namespace CleanArc.Domain.Accounts.ValueObjects;

public sealed partial record Email : ValueObject
{
    #region [ Constants ]
    
    private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
    public const int MinLength = 6;
    public const int MaxLength = 160;
    
    #endregion
    
    #region [ Constructors ]
    
    private Email(string address)
    {
        Address = address;
    }
    
    #endregion
    
    #region [ Factory Methods ]

    public static Email Create(string address)
    {
        if (string.IsNullOrEmpty(address) ||
            string.IsNullOrWhiteSpace(address))
            throw new InvalidEmailLengthException($"Email must not be empty.");

        address = address.Trim();
        address = address.ToLower();
        
        if (!EmailRegex().IsMatch(address))
            throw new InvalidEmailException($"Email {address} is not valid.");       
        
        return new Email(address);       
    }
    
    #endregion
    
    #region [ Properties ]

    public string Address { get; }
    
    #endregion
    
    #region [ Operators ]
    
    public static implicit operator string(Email email) => email.ToString();
    
    #endregion
    
    #region [ Overrides ]
    
    public override string ToString() => Address;
    
    #endregion

    #region [ Generators ]
    
    [GeneratedRegex(Pattern)]
    private static partial Regex EmailRegex();
    
    #endregion
}