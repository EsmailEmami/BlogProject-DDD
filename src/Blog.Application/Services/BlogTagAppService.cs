using Blog.Application.Interfaces;
using Blog.Domain.Commands.BlogTag;
using Blog.Domain.Core.Bus;
using Blog.Domain.Queries.BlogTag;

namespace Blog.Application.Services;

public class BlogTagAppService : IBlogTagAppService
{
    private readonly IMediatorHandler _bus;

    public BlogTagAppService(IMediatorHandler bus)
    {
        _bus = bus;
    }

    public async Task<bool> AddBlogTagAsync(Guid blogId, Guid tagId)
    {
        try
        {
            RegisterNewBlogTagCommand command = new RegisterNewBlogTagCommand(blogId, tagId);
            return await _bus.SendCommand<RegisterNewBlogTagCommand, bool>(command);
        }
        catch
        {
            return false;
        }
    }

    public void DeleteBlogTag(Guid blogTagId)
    {
        RemoveBlogTagCommand command = new RemoveBlogTagCommand(blogTagId);
        _bus.SendCommand<RemoveBlogTagCommand, bool>(command);
    }

    public async Task<List<Guid>> GetBlogTags(Guid blogId)
    {
        GetBlogTagsIdByBlogQuery query = new GetBlogTagsIdByBlogQuery(blogId);
        try
        {
            return await _bus.SendQuery<GetBlogTagsIdByBlogQuery, List<Guid>>(query);
        }
        catch
        {
            return new List<Guid>();
        }
    }

    public void Dispose() => GC.SuppressFinalize(this);
}