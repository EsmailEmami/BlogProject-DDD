using Blog.Domain.Validations.Command.BlogCategory;

namespace Blog.Domain.Commands.BlogCategory;

public class RegisterNewBlogCategoryCommand : BlogCategoryCommand<bool>
{
    public RegisterNewBlogCategoryCommand(Guid blogId, Guid categoryId)
    {
        BlogId = blogId;
        CategoryId = categoryId;
    }

    public override bool IsValid()
    {
        ValidationResult = new RegisterNewBlogCategoryCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}