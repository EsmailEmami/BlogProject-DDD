using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.ViewModels.Tag;
using Dapper;
using System.Data;

namespace Blog.Infra.Data.Repository;

public class TagRepository : Repository<Tag>, ITagRepository
{
    public TagRepository(IDbConnection db) : base(db)
    {
    }

    public List<TagForShowViewModel> GetAllTags()
    {
        string query = "SELECT  [Id] AS [TagId], [TagName] " +
            "FROM[Tag].[Tags]";

        return Db.Query<TagForShowViewModel>(query).ToList();
    }

    public UpdateTagViewModel? GetTagForUpdate(Guid tagId)
    {
        string query = "SELECT [Id] AS [TagId], [TagName] " +
            "FROM [Tag].[Tags] " +
            "WHERE [Id] = @TagId";

        return Db.QuerySingleOrDefault<UpdateTagViewModel>(query, new
        {
            TagId = tagId
        });
    }

    public List<TagForShowViewModel> GetBLogTags(Guid blogId)
    {
        string query = "SELECT [Tags].[Id] AS [TagId], [Tags].[TagName] " +
                       "FROM [Tag].[BlogTags] " +
                       "INNER JOIN [Tag].[Tags] " +
                       "ON [Tag].[BlogTags].[TagId] = [Tag].[Tags].[Id] " +
                       "WHERE [BlogTags].[BlogId] = @BlogId";

        return Db.Query<TagForShowViewModel>(query, new
        {
            blogId
        }).ToList();
    }
}