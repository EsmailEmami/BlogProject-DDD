using Blog.Domain.Queries.Blog;
using Blog.Domain.ViewModels.Blog;

namespace Blog.Domain.Validations.Query.Blog;

public class GetBlogForUpdateQueryValidation : BlogQueryValidation<GetBlogForUpdateQuery, UpdateBlogViewModel>
{
    public GetBlogForUpdateQueryValidation()
    {
        ValidateId();
    }
}