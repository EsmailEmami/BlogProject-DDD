namespace Blog.Domain.Queries.Tag;

public class GetTagsQuery : TagQuery<List<Models.Tag>>
{
    public override bool IsValid() => true;
}