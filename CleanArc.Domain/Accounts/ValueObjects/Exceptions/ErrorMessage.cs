namespace CleanArc.Domain.Accounts.ValueObjects.Exceptions;

public static class ErrorMessage
{
    #region [ Properties ]

    public static NameErrorMessages Name { get; } = new();
    public static EmailErrorMessages Email { get; } = new();

    #endregion
    
    public class NameErrorMessages
    {
        public string NameExists => "Name already exists.";
        
        public string InvalidNullOrEmpty { get; set; } = "Name must not be empty.";

        public string InvalidMinLength { get; set; } = $"Name must not be less than {ValueObjects.Name.MinLength} characters.";
        
        public string InvalidMaxLength { get; set; } = $"Name must not be greater than {ValueObjects.Name.MaxLength} characters.";
    }    
    
    public class EmailErrorMessages
    {
        public string EmailExists => "Email already exists.";       
        
        public string InvalidNullOrEmpty => "Email must not be empty.";
        
        public string InvalidEmail => "Email is not valid.";
        
        public string InvalidMinLength => $"Email must not be less than {ValueObjects.Email.MinLength} characters.";
        
        public string InvalidMaxLength => $"Email must not be greater than {ValueObjects.Email.MaxLength} characters.";       
    }
}