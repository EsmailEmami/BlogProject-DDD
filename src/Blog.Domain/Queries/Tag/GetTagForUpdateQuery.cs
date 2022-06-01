using Blog.Domain.Validations.Query.Tag;
using Blog.Domain.ViewModels.Tag;

namespace Blog.Domain.Queries.Tag;

public class GetTagForUpdateQuery : TagQuery<UpdateTagViewModel>
{
    public GetTagForUpdateQuery(Guid tagId)
    {
        Id = tagId;
    }

    public override bool IsValid()
    {
        ValidationResult = new GetTagForUpdateQueryValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}

