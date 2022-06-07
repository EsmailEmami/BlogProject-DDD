using Blog.Domain.ViewModels.Blog;

namespace Blog.Domain.Queries.Blog;

public class GetBlogsQuery : BlogQuery<List<BlogForShowViewModel>>
{
    public GetBlogsQuery()
    {
    }

    public override bool IsValid() => true;
}