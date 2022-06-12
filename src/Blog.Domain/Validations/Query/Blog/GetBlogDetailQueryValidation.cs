using Blog.Domain.Queries.Blog;
using Blog.Domain.ViewModels.Blog;

namespace Blog.Domain.Validations.Query.Blog;

public class GetBlogDetailQueryValidation : BlogQueryValidation<GetBlogDetailQuery, BlogDetailViewModel>
{
    public GetBlogDetailQueryValidation()
    {
        ValidateId();
    }
}