using Blog.Domain.Commands.User;
using FluentValidation;

namespace Blog.Domain.Validations.User;

public abstract class UserValidation<T> : AbstractValidator<T> where T : UserCommand
{
    protected void ValidateFirstName()
    {
        RuleFor(c => c.FirstName)
            .NotEmpty().WithMessage("Please ensure you have entered the First Name")
            .Length(3, 50).WithMessage("The First Name must have between 3 and 50 characters");
    }

    protected void ValidateLastName()
    {
        RuleFor(c => c.LastName)
            .NotEmpty().WithMessage("Please ensure you have entered the Last Name")
            .Length(3, 50).WithMessage("The Last Name must have between 3 and 50 characters");
    }

    protected void ValidateEmail()
    {
        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("Please ensure you have entered the Email Address")
            .EmailAddress().WithMessage("Please ensure you have entered the valid Email Address")
            .MaximumLength(100).WithMessage("The Last Name must not be more than 100 characters");
    }

    protected void ValidatePassword()
    {
        RuleFor(c => c.Password)
            .NotEmpty().WithMessage("Please ensure you have entered the Password")
            .Equal(c => c.ConfirmPassword).WithMessage("Please ensure password is match")
            .Length(6, 50).WithMessage("The Password must have between 3 and 50 characters")
            .Matches("[A-Z]").WithMessage("The password must be contains uppercase character")
            .Matches("[a-z]").WithMessage("The password must be contains lowercase character")
            .Matches("[^#?!@$%^&*-]").WithMessage("special character");
    }

    protected void ValidateId()
    {
        RuleFor(c => c.Id)
            .NotEqual(Guid.Empty);
    }
}