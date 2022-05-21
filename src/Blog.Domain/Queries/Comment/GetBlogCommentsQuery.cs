using Blog.Domain.Validations.Query.Comment;
using Blog.Domain.ViewModels.Comment;

namespace Blog.Domain.Queries.Comment;

public class GetBlogCommentsQuery : CommentQuery<List<CommentForShowViewModel>>
{
    public GetBlogCommentsQuery(Guid blogId)
    {
        BlogId = blogId;
    }
    public override bool IsValid()
    {
        ValidationResult = new GetBlogCommentsQueryValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}