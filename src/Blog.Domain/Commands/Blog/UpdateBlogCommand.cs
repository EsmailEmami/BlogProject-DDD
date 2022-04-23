using Blog.Domain.Validations.Blog;

namespace Blog.Domain.Commands.Blog;

public class UpdateBlogCommand : BlogCommand<bool>
{
    public UpdateBlogCommand(Guid id,Guid authorId, string blogTitle, string summary, string description,
        string imageFile, string readTime)
    {
        Id = id;
        AuthorId = authorId;
        BlogTitle = blogTitle;
        Summary = summary;
        Description = description;
        ImageFile = imageFile;
        ReadTime = readTime;
    }

    public override bool IsValid()
    {
        ValidationResult = new UpdateBlogCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}