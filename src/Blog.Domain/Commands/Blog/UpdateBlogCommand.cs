using Blog.Domain.Validations.Blog;

namespace Blog.Domain.Commands.Blog;

public class UpdateBlogCommand : BlogCommand
{
    public UpdateBlogCommand(Guid id, string blogTitle)
    {
        Id = id;
        BlogTitle = blogTitle;
    }

    public override bool IsValid()
    {
        ValidationResult = new UpdateBlogCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}