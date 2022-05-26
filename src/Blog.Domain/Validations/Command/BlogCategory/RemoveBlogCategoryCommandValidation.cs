using Blog.Domain.Commands.BlogCategory;

namespace Blog.Domain.Validations.Command.BlogCategory;

public class RemoveBlogCategoryCommandValidation : BlogCategoryCommandValidation<RemoveBlogCategoryCommand, bool>
{
    public RemoveBlogCategoryCommandValidation()
    {
        ValidateId();
    }
}