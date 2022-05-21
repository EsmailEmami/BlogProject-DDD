using Blog.Domain.Queries.Blog;
using Blog.Domain.ViewModels.Blog;

namespace Blog.Domain.Validations.Query.Blog;

public class GetAuthorBlogsQueryValidation : BlogQueryValidation<GetAuthorBlogsQuery, List<BlogForShowViewModel>>
{
    public GetAuthorBlogsQueryValidation()
    {
        ValidateAuthorId();
    }
}