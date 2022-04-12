using Blog.Domain.Commands.Blog;

namespace Blog.Domain.Validations.Blog;

public class UpdateBlogCommandValidation : BlogValidation<UpdateBlogCommand>
{
    public UpdateBlogCommandValidation()
    {
        ValidateId();
        ValidateTitle();
    }
}