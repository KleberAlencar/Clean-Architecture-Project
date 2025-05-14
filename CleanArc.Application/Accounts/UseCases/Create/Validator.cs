using FluentValidation;
using CleanArc.Domain.Accounts.ValueObjects;
using CleanArc.Domain.Accounts.ValueObjects.Exceptions;

namespace CleanArc.Application.Accounts.UseCases.Create;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        RuleFor(x => x.FirstName)
            .NotNull()
            .WithMessage(ErrorMessage.Name.InvalidNullOrEmpty);
        
        RuleFor(x => x.LastName)
            .NotNull()
            .WithMessage(ErrorMessage.Name.InvalidNullOrEmpty);        
        
        RuleFor(x => $"{x.FirstName} {x.LastName}")
            .MinimumLength(Name.MinLength)
            .WithMessage(ErrorMessage.Name.InvalidMinLength);
        
        RuleFor(x => $"{x.FirstName} {x.LastName}")
            .MinimumLength(Name.MaxLength)
            .WithMessage(ErrorMessage.Name.InvalidMaxLength);        

        RuleFor(x => x.Email)
            .NotNull()
            .WithMessage(ErrorMessage.Email.InvalidNullOrEmpty);       
        
        RuleFor(x => x.Email)
            .MinimumLength(Email.MinLength)
            .WithMessage(ErrorMessage.Email.InvalidMinLength);
        
        RuleFor(x => x.Email)
            .MaximumLength(Email.MaxLength)
            .WithMessage(ErrorMessage.Email.InvalidMaxLength);

        RuleFor(x => x.Email)
            .Matches(Email.Pattern)
            .WithMessage(ErrorMessage.Email.InvalidEmail);
    }
}