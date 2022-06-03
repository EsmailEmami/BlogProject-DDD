namespace Blog.Application.Interfaces;

public interface IBlogTagAppService : IDisposable
{
    Task<bool> AddBlogTagAsync(Guid blogId, Guid tagId);
    void DeleteBlogTag(Guid blogTagId);
    Task<List<Guid>> GetBlogTags(Guid blogId);
}