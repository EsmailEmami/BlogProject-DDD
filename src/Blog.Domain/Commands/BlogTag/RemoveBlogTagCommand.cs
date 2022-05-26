using Blog.Domain.Validations.Command.BlogTag;

namespace Blog.Domain.Commands.BlogTag;

public class RemoveBlogTagCommand:BlogTagCommand
{
    public RemoveBlogTagCommand(Guid blogTagId)
    {
        Id = blogTagId;
    }

    public override bool IsValid()
    {
        ValidationResult = new RemoveBlogTagCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}