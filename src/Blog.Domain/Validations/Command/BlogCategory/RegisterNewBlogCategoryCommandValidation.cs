using Blog.Domain.Commands.BlogCategory;

namespace Blog.Domain.Validations.Command.BlogCategory;

public class RegisterNewBlogCategoryCommandValidation : BlogCategoryCommandValidation<RegisterNewBlogCategoryCommand, Guid>
{
    public RegisterNewBlogCategoryCommandValidation()
    {
        ValidateBlogId();
        ValidateCategoryId();
    }
}