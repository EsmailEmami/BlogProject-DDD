using Blog.Domain.Validations.Command.BlogTag;

namespace Blog.Domain.Commands.BlogTag;

public class RegisterNewBlogTagCommand : BlogTagCommand
{
    public RegisterNewBlogTagCommand(Guid blogId, Guid tagId)
    {
        BlogId = blogId;
        TagId = tagId;
    }

    public override bool IsValid()
    {
        ValidationResult = new RegisterNewBlogTagCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}