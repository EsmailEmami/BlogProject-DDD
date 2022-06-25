using Blog.Domain.Validations.Command.Category;
using Blog.Domain.ViewModels.Category;

namespace Blog.Domain.Commands.Category;

public class RegisterNewCategoryCommand : CategoryCommand<CategoryForShowViewModel>
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