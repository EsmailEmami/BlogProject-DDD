using Blog.Domain.Models;
using Blog.Domain.ViewModels.Tag;

namespace Blog.Domain.Interfaces;

public interface ITagRepository : IRepository<Tag>
{
    List<TagForShowViewModel> GetAllTags();
    UpdateTagViewModel? GetTagForUpdate(Guid tagId);
    List<TagForShowViewModel> GetBLogTags(Guid blogId);
}