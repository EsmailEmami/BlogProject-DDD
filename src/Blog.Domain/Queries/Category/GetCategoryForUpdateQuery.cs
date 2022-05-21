using Blog.Domain.Validations.Query.Category;
using Blog.Domain.ViewModels.Blog;
using Blog.Domain.ViewModels.Category;

namespace Blog.Domain.Queries.Category;

public class GetCategoryForUpdateQuery:CategoryQuery<UpdateCategoryViewModel>
{
    public GetCategoryForUpdateQuery(Guid categoryId)
    {
        Id = categoryId;
    }

    public override bool IsValid()
    {
        ValidationResult = new GetCategoryForUpdateQueryValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}