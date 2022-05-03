using Blog.Domain.Validations.BlogCategory;

namespace Blog.Domain.Commands.BlogCategory;

public class RegisterNewBlogCategoryCommand : BlogCategoryCommand<Guid>
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