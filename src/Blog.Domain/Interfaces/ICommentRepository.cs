using Blog.Domain.Models;
using Blog.Domain.ViewModels.Comment;

namespace Blog.Domain.Interfaces;

public interface ICommentRepository : IRepository<Comment>
{
    List<CommentForShowViewModel> GetBlogComments(Guid blogId);
}