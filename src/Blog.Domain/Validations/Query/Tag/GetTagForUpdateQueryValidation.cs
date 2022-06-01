using Blog.Domain.Queries.Tag;
using Blog.Domain.ViewModels.Tag;

namespace Blog.Domain.Validations.Query.Tag;

public class GetTagForUpdateQueryValidation : TagQueryValidation<GetTagForUpdateQuery, UpdateTagViewModel>
{
    public GetTagForUpdateQueryValidation()
    {
        ValidateId();
    }
}

