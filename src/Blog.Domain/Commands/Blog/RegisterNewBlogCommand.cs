using Blog.Domain.Validations.Blog;
using MediatR;

namespace Blog.Domain.Commands.Blog;

public class RegisterNewBlogCommand : BlogCommand<Guid>
{
    public RegisterNewBlogCommand(string blogTitle)
    {
        BlogTitle = blogTitle;
    }

    public override bool IsValid()
    {
        ValidationResult = new RegisterNewBlogCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}