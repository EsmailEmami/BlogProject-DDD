using Blog.Domain.Validations.Query.Blog;
using Blog.Domain.ViewModels.Blog;

namespace Blog.Domain.Queries.Blog;

public class GetAuthorBlogsQuery : BlogQuery<List<BlogForShowViewModel>>
{
    public GetAuthorBlogsQuery(Guid authorId)
    {
        AuthorId = authorId;
    }

    public override bool IsValid()
    {
        ValidationResult = new GetAuthorBlogsQueryValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}