using Blog.Domain.Commands.Blog;

namespace Blog.Domain.Validations.Blog;

public class RemoveBlogCommandValidation : BlogValidation<RemoveBlogCommand, bool>
{
    public RemoveBlogCommandValidation()
    {
        ValidateId();
    }
}