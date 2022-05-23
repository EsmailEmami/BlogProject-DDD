using Blog.Domain.Validations.Command.Tag;

namespace Blog.Domain.Commands.Tag;

public class RegisterNewTagCommand : TagCommand<Guid>
{
    public RegisterNewTagCommand(string tagName)
    {
        TagName = tagName;
    }

    public override bool IsValid()
    {
        ValidationResult = new RegisterNewTagCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}