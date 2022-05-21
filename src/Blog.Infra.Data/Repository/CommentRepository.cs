using System.Data;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;

namespace Blog.Infra.Data.Repository;

public class CommentRepository : Repository<Comment>, ICommentRepository
{
    public CommentRepository(IDbConnection db, IDbTransaction transaction) : base(db, transaction)
    {
    }
}