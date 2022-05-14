using Blog.Domain.Validations.Command.User;
using FluentValidation.Results;

namespace Blog.Domain.Commands.User;

public class RemoveUserCommand : UserCommand<bool>
{
    public RemoveUserCommand(Guid id)
    {
        Id = id;
    }
    public override bool IsValid()
    {
        ValidationResult = new RemoveUserCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}