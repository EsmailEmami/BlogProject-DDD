using Blog.Domain.Validations.Query.Category;
using Blog.Domain.ViewModels.Category;

namespace Blog.Domain.Queries.Category;

public class GetBlogCategoriesQuery : CategoryQuery<List<CategoryForShowViewModel>>
{
    public GetBlogCategoriesQuery(Guid blogId)
    {
        BlogId = blogId;
    }

    public override bool IsValid()
    {
        ValidationResult = new GetBlogCategoriesQueryValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}