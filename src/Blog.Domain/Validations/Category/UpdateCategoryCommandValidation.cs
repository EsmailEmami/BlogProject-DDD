using Blog.Domain.Commands.Category;

namespace Blog.Domain.Validations.Category;

public class UpdateCategoryCommandValidation : CategoryValidation<UpdateCategoryCommand, bool>
{
    public UpdateCategoryCommandValidation()
    {
        ValidateId();
        ValidateTitle();
    }
}