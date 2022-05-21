using System.Data;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.ViewModels.Comment;

namespace Blog.Infra.Data.Repository;

public class CommentRepository : Repository<Comment>, ICommentRepository
{
    public CommentRepository(IDbConnection db, IDbTransaction transaction) : base(db, transaction)
    {
    }

    public List<CommentForShowViewModel> GetBlogComments(Guid blogId)
    {
        return new List<CommentForShowViewModel>();
    }
}