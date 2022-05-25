using Blog.Domain.Validations.Command.Tag;

namespace Blog.Domain.Commands.Tag;

public class UpdateTagCommand : TagCommand<bool>
{
    public UpdateTagCommand(Guid tagId, string tagName)
    {
        Id = tagId;
        TagName = tagName;
    }

    public override bool IsValid()
    {
        ValidationResult = new UpdateTagCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}