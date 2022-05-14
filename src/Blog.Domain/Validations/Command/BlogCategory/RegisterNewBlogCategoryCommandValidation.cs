using Blog.Domain.Commands.BlogCategory;

namespace Blog.Domain.Validations.Command.BlogCategory;

public class RegisterNewBlogCategoryCommandValidation : BlogCategoryValidation<RegisterNewBlogCategoryCommand, Guid>
{
    public RegisterNewBlogCategoryCommandValidation()
    {
        ValidateBlogId();
        ValidateCategoryId();
    }
}