using Blog.Domain.Validations.Command.Tag;

namespace Blog.Domain.Commands.Tag;

public class RemoveTagCommand:TagCommand<bool>
{
    public RemoveTagCommand(Guid tagId)
    {
        Id = tagId;
    }

    public override bool IsValid()
    {
        ValidationResult = new RemoveTagCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}