using Blog.Domain.Commands.Blog;

namespace Blog.Domain.Validations.Blog;

public class UpdateBlogCommandValidation : BlogValidation<UpdateBlogCommand, bool>
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