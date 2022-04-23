using Blog.Domain.Commands.Blog;

namespace Blog.Domain.Validations.Blog;

public class RegisterNewBlogCommandValidation : BlogValidation<RegisterNewBlogCommand, Guid>
{
    public RegisterNewBlogCommandValidation()
    {
        ValidateAuthorId();
        ValidateTitle();
        ValidateSummary();
        ValidateDescription();
        ValidateImageFile();
        ValidateReadTime();
    }
}