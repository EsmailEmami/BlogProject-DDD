using Blog.Domain.ViewModels.Tag;

namespace Blog.Application.Interfaces;

public interface ITagAppService : IDisposable
{
    void AddTag(AddTagViewModel tag);
    void UpdateTag(UpdateTagViewModel tag);
    void DeleteTag(Guid tagId);
    Task<List<TagForShowViewModel>> GetAllTagsAsync();
    Task<UpdateTagViewModel?> GetTagForUpdateAsync(Guid tagId);
    Task<List<TagForShowViewModel>> GetBlogTags(Guid blogId);
}