using Blog.Domain.ViewModels.Category;

namespace Blog.Domain.Queries.Category;

public class GetAllCategoriesQuery : CategoryQuery<List<CategoryForShowViewModel>>
{
    public GetAllCategoriesQuery()
    {
    }

    public override bool IsValid() => true;
}

