using Blog.Domain.Validations.Category;

namespace Blog.Domain.Commands.Category;

public class UpdateCategoryCommand : CategoryCommand<bool>
{
    public UpdateCategoryCommand(Guid id,string title)
    {
        Id = id;
        CategoryTitle = title;
    }

    public override bool IsValid()
    {
        ValidationResult = new UpdateCategoryCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}