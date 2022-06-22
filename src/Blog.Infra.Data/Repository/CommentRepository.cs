using System.Data;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.ViewModels.Comment;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Blog.Infra.Data.Repository;

public class CommentRepository : Repository<Comment>, ICommentRepository
{
    public CommentRepository(IDbConnection db) : base(db)
    {
    }

    public List<CommentForShowViewModel> GetBlogComments(Guid blogId)
    {
        string query = "SELECT [Comments].[Id] AS [CommentId], " +
                       "CONCAT([Users].[FirstName], ' ',[Users].[LastName]) AS [FullName], " +
                       "[Comments].[Title], " +
                       "[Comments].[CommentMessage], " +
                       "[Comments].[CommentDate] " +
                       "FROM [User].[Comments] " +
                       "INNER JOIN [User].[Users] " +
                       "ON [User].[Comments].[UserId] = [User].[Users].[Id] " +
                       "WHERE [BlogId] = @BlogId " +
                       "ORDER BY [Comments].[CommentDate] DESC";

        return Db.Query<CommentForShowViewModel>(query, new
        {
            blogId
        }).ToList();
    }

    public new CommentForShowViewModel Add(Comment obj)
    {
        string query = "INSERT INTO [User].[Comments] ([UserId],[BlogId],[Title],[CommentMessage]) " +
                       "VALUES (@UserId, @BlogId, @Title, @CommentMessage)";

        return Db.QuerySingleOrDefault<CommentForShowViewModel>(query, new
        {
            obj.UserId,
            obj.BlogId,
            obj.Title,
            obj.CommentMessage
        });
    }
}