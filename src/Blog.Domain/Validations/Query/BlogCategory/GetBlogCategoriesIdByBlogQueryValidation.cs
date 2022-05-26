using Blog.Domain.Queries.BlogCategory;
using Blog.Domain.Queries.BlogTag;
using Blog.Domain.Validations.Query.BlogTag;

namespace Blog.Domain.Validations.Query.BlogCategory;

public class GetBlogCategoriesIdByBlogQueryValidation : BlogCategoryQueryValidation<GetBlogCategoriesIdByBlogQuery, List<Guid>>
{
    public GetBlogCategoriesIdByBlogQueryValidation()
    {
        ValidateBlogId();
    }
}