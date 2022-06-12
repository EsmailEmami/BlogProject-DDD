using Blog.Domain.Validations.Query.Tag;
using Blog.Domain.ViewModels.Tag;

namespace Blog.Domain.Queries.Tag;

public class GetBlogTagsQuery : TagQuery<List<TagForShowViewModel>>
{
    public GetBlogTagsQuery(Guid blogId)
    {
        BlogId = blogId;
    }

    public override bool IsValid()
    {
        ValidationResult = new GetBlogTagsQueryValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}