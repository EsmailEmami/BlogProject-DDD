using Blog.Domain.Queries.Comment;
using Blog.Domain.ViewModels.Comment;

namespace Blog.Domain.Validations.Query.Comment;

public class GetBlogCommentsQueryValidation : CommentQueryValidation<GetBlogCommentsQuery, List<CommentForShowViewModel>>
{
    public GetBlogCommentsQueryValidation()
    {
        ValidateBlogId();
    }
}