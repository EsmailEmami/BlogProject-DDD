using Blog.Domain.Validations.Query.BlogTag;

namespace Blog.Domain.Queries.BlogTag;

public class GetBlogTagsIdByBlogQuery : BlogTagQuery<List<Guid>>
{
    public GetBlogTagsIdByBlogQuery(Guid blogId)
    {
        BlogId = blogId;
    }

    public override bool IsValid()
    {
        ValidationResult = new GetBlogTagsIdByBlogQueryValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}