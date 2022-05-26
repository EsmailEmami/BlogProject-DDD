namespace Blog.Application.Interfaces;

public interface IBlogTagAppService : IDisposable
{
    void AddBlogTag(Guid blogId, Guid tagId);
    void DeleteBlogTag(Guid blogTagId);
    Task<List<Guid>> GetBlogTags(Guid blogId);
}