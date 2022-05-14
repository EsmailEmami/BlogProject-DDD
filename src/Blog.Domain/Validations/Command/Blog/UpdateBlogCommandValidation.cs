using Blog.Domain.Commands.Blog;

namespace Blog.Domain.Validations.Command.Blog;

public class UpdateBlogCommandValidation : BlogCommandValidation<UpdateBlogCommand, bool>
{
    public UpdateBlogCommandValidation()
    {
        ValidateId();
        ValidateAuthorId();
        ValidateTitle();
        ValidateSummary();
        ValidateDescription();
        ValidateImageFile();
        ValidateReadTime();
    }
}