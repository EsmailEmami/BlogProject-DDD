using Blog.Domain.Validations.Command.Blog;

namespace Blog.Domain.Commands.Blog;

public class RegisterNewBlogCommand : BlogCommand<Guid>
{
    public RegisterNewBlogCommand(Guid authorId, string blogTitle, string summary, string description,
        string imageFile, string readTime)
    {
        AuthorId = authorId;
        BlogTitle = blogTitle;
        Summary = summary;
        Description = description;
        ImageFile = imageFile;
        ReadTime = readTime;
    }

    public override bool IsValid()
    {
        ValidationResult = new RegisterNewBlogCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}