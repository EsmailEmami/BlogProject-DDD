using Blog.Domain.Commands.BlogCategory;

namespace Blog.Domain.Validations.Command.BlogCategory;

public class RegisterNewBlogCategoryCommandValidation : BlogCategoryCommandValidation<RegisterNewBlogCategoryCommand, bool>
{
    public RegisterNewBlogCategoryCommandValidation()
    {
        ValidateBlogId();
        ValidateCategoryId();
    }
}