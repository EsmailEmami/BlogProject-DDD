using Blog.Domain.Queries.BlogTag;

namespace Blog.Domain.Validations.Query.BlogTag;

public class GetBlogTagsIdByBlogQueryValidation : BlogTagQueryValidation<GetBlogTagsIdByBlogQuery, List<Guid>>
{
    public GetBlogTagsIdByBlogQueryValidation()
    {
        ValidateBlogId();
    }
}