using Blog.Domain.Commands.Comment;
using Blog.Domain.Commands.Role;
using FluentValidation;

namespace Blog.Domain.Validations.Command.Role;

public abstract class RoleCommandValidation<TCommand, TResult> : AbstractValidator<TCommand> 
    where TCommand : RoleCommand<TResult>
{
    protected void ValidateId()
    {
        RuleFor(c => c.RoleId)
            .NotEqual(Guid.Empty);
    }

    protected void ValidateRoleName()
    {
        RuleFor(c => c.RoleName)
            .NotEmpty().WithMessage("لطفا نام مقام را وارد کنید")
            .Length(3, 20).WithMessage("نام مقام وارد شده باید بین 3 تا 20 کاراکتر باشد")
            .Must(c => !string.IsNullOrWhiteSpace(c)).WithMessage("لطفا از فاصله استفاده نکنید");
    }
}