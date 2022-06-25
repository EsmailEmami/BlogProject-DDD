using Blog.Domain.Commands.Category;
using Blog.Domain.ViewModels.Category;

namespace Blog.Domain.Validations.Command.Category;

public class RegisterNewCategoryCommandValidation : CategoryCommandValidation<RegisterNewCategoryCommand, CategoryForShowViewModel>
{
    public RegisterNewCategoryCommandValidation()
    {
        ValidateTitle();
    }
}