using Blog.Domain.Queries.Blog;
using Blog.Domain.Queries.User;
using FluentValidation;

namespace Blog.Domain.Validations.Query.User;

public abstract class UserQueryValidation<TQuery, TResult> : AbstractValidator<TQuery>
    where TQuery : UserQuery<TResult>
{
    protected void ValidateId()
    {
        RuleFor(c => c.UserId)
            .NotEqual(Guid.Empty).WithMessage("لطفا آیدی کاربر را وارد کنید");
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
            .MaximumLength(300).WithMessage("The Password must have between 3 and 50 characters");
    }
}