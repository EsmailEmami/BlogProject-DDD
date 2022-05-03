using Blog.Domain.Validations.Category;

namespace Blog.Domain.Commands.Category;

public class RegisterNewCategoryCommand : CategoryCommand<Guid>
{
    public RegisterNewCategoryCommand(string title)
    {
        CategoryTitle = title;
    }
    public override bool IsValid()
    {
        ValidationResult = new RegisterNewCategoryCommandValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}