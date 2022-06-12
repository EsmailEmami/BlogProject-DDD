using Blog.Domain.ViewModels.Comment;

namespace Blog.Application.Interfaces;

public interface ICommentAppService : IDisposable
{
    Task<List<CommentForShowViewModel>> GetBlogCommentsAsync(Guid blogId);
}
