using Blog.Domain.Commands.Blog;

namespace Blog.Domain.Validations.Command.Blog;

public class RemoveBlogCommandValidation : BlogCommandValidation<RemoveBlogCommand, bool>
{
    public RemoveBlogCommandValidation()
    {
        ValidateId();
    }
}