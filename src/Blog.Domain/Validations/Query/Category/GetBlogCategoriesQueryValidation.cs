using Blog.Domain.Queries.Category;
using Blog.Domain.ViewModels.Category;

namespace Blog.Domain.Validations.Query.Category;

public class GetBlogCategoriesQueryValidation : CategoryQueryValidation<GetBlogCategoriesQuery, List<CategoryForShowViewModel>>
{
    public GetBlogCategoriesQueryValidation()
    {
        ValidateBlogId();
    }
}