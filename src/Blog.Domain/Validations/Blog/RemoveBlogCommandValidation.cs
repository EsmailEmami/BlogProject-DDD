using Blog.Domain.Commands.Blog;

namespace Blog.Domain.Validations.Blog;

public class RemoveBlogCommandValidation:BlogValidation<RemoveBlogCommand>
{
    public RemoveBlogCommandValidation()
    {
        ValidateId();
    }
}