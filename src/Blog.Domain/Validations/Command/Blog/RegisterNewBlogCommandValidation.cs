using Blog.Domain.Commands.Blog;

namespace Blog.Domain.Validations.Command.Blog;

public class RegisterNewBlogCommandValidation : BlogCommandValidation<RegisterNewBlogCommand, Guid>
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