using Blog.Domain.Queries.Tag;
using Blog.Domain.ViewModels.Tag;

namespace Blog.Domain.Validations.Query.Tag;

public class GetBlogTagsQueryValidation : TagQueryValidation<GetBlogTagsQuery, List<TagForShowViewModel>>
{
    public GetBlogTagsQueryValidation()
    {
        ValidateBlogId();
    }
}