using Blog.Domain.ViewModels.Comment;

namespace Blog.Application.Interfaces;

public interface ICommentAppService : IDisposable
{
    Task<Guid> AddCommentAsync(AddCommentViewModel comment);
    Task<List<CommentForShowViewModel>> GetBlogCommentsAsync(Guid blogId);
}
