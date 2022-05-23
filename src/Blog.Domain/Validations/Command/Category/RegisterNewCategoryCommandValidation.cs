using Blog.Domain.Commands.Category;

namespace Blog.Domain.Validations.Command.Category;

public class RegisterNewCategoryCommandValidation : CategoryCommandValidation<RegisterNewCategoryCommand, Guid>
{
    public RegisterNewCategoryCommandValidation()
    {
        ValidateTitle();
    }
}