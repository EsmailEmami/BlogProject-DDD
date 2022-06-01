using Blog.Domain.ViewModels.Tag;

namespace Blog.Domain.Queries.Tag;

public class GetTagsQuery : TagQuery<List<TagForShowViewModel>>
{
    public GetTagsQuery()
    {
    }

    public override bool IsValid() => true;
}