namespace Blog.Domain.Specifications.Blog;

public sealed class BlogFilterPaginatedSpecification : BaseSpecification<Models.Blog>
{
    public BlogFilterPaginatedSpecification(int skip, int take)
        : base(_ => true)
    {
        ApplyPaging(skip, take);
    }
}