using Blog.Domain.Commands.Category;

namespace Blog.Domain.Validations.Command.Category;

public class UpdateCategoryCommandValidation : CategoryValidation<UpdateCategoryCommand, bool>
{
    public UpdateCategoryCommandValidation()
    {
        ValidateId();
        ValidateTitle();
    }
}