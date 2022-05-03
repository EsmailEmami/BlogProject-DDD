using Blog.Domain.Commands.Category;

namespace Blog.Domain.Validations.Category;

public class RegisterNewCategoryCommandValidation : CategoryValidation<RegisterNewCategoryCommand, Guid>
{
    public RegisterNewCategoryCommandValidation()
    {
        ValidateTitle();
    }
}