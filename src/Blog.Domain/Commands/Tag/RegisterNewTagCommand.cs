using Blog.Domain.Validations.Command.Tag;
using Blog.Domain.ViewModels.Tag;

namespace Blog.Domain.Commands.Tag;

public class RegisterNewTagCommand : TagCommand<TagForShowViewModel>
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