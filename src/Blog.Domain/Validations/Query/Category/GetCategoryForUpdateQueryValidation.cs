using Blog.Domain.Queries.Category;
using Blog.Domain.ViewModels.Category;

namespace Blog.Domain.Validations.Query.Category;

public class GetCategoryForUpdateQueryValidation : CategoryQueryValidation<GetCategoryForUpdateQuery, UpdateCategoryViewModel>
{
    public GetCategoryForUpdateQueryValidation()
    {
        ValidateId();
    }
}