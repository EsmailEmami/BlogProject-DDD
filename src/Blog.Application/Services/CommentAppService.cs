using Blog.Application.Interfaces;
using Blog.Domain.Core.Bus;
using Blog.Domain.Queries.Comment;
using Blog.Domain.ViewModels.Comment;

namespace Blog.Application.Services;

public class CommentAppService : ICommentAppService
{
    private readonly IMediatorHandler _bus;

    public CommentAppService(IMediatorHandler bus)
    {
        _bus = bus;
    }

    public async Task<List<CommentForShowViewModel>> GetBlogCommentsAsync(Guid blogId)
    {
        GetBlogCommentsQuery query = new GetBlogCommentsQuery(blogId);

        try
        {
            return await _bus.SendQuery<GetBlogCommentsQuery, List<CommentForShowViewModel>>(query);
        }
        catch
        {
            return new List<CommentForShowViewModel>();
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}