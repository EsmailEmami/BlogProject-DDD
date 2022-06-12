using Blog.Domain.Validations.Query.Blog;
using Blog.Domain.ViewModels.Blog;

namespace Blog.Domain.Queries.Blog;

public class GetBlogDetailQuery : BlogQuery<BlogDetailViewModel>
{
    public GetBlogDetailQuery(Guid blogId)
    {
        Id = blogId;
    }

    public override bool IsValid()
    {
        ValidationResult = new GetBlogDetailQueryValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}