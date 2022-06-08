using Blog.Domain.Commands.UserRole;
using FluentValidation;

namespace Blog.Domain.Validations.Command.UserRole;

public abstract class UserRoleCommandValidation<TCommand> : AbstractValidator<TCommand> where TCommand : UserRoleCommand
{
    protected void ValidateUserId()
    {
        RuleFor(c => c.UserId)
            .NotEqual(Guid.Empty);
    }
    protected void ValidateRoleId()
    {
        RuleFor(c => c.RoleId)
            .NotEqual(Guid.Empty);
    }
    protected void ValidateId()
    {
        RuleFor(c => c.Id)
            .NotEqual(Guid.Empty);
    }
}