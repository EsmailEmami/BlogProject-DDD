using Blog.Domain.Validations.Query.BlogCategory;

namespace Blog.Domain.Queries.BlogCategory;

public class GetBlogCategoriesIdByBlogQuery : BlogCategoryQuery<List<Guid>>
{
    public GetBlogCategoriesIdByBlogQuery(Guid blogId)
    {
        BlogId = blogId;
    }

    public override bool IsValid()
    {
        ValidationResult = new GetBlogCategoriesIdByBlogQueryValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}