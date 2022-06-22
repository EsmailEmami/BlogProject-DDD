using Blog.Domain.ViewModels.Comment;

namespace Blog.Application.Interfaces;

public interface ICommentAppService : IDisposable
{
    Task<CommentForShowViewModel> AddCommentAsync(AddCommentViewModel comment);
    Task<List<CommentForShowViewModel>> GetBlogCommentsAsync(Guid blogId);
}
