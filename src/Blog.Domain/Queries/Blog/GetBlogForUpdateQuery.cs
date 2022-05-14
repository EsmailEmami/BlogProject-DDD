using Blog.Domain.Validations.Query.Blog;
using Blog.Domain.ViewModels.Blog;

namespace Blog.Domain.Queries.Blog;

public class GetBlogForUpdateQuery : BlogQuery<UpdateBlogViewModel>
{
    public GetBlogForUpdateQuery(Guid blogId)
    {
        Id = blogId;
    }

    public override bool IsValid()
    {
        ValidationResult = new GetBlogForUpdateQueryValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}