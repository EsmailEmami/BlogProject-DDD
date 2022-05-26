using Blog.Domain.Validations.Command.BlogCategory;

namespace Blog.Domain.Commands.BlogCategory;

public class RemoveBlogCategoryCommand : BlogCategoryCommand<bool>
{
    public RemoveBlogCategoryCommand(Guid blogCategoryId)
    {
        Id = blogCategoryId;
    }

    public override bool IsValid()
    {
        ValidationResult = new RemoveBlogCategoryCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}