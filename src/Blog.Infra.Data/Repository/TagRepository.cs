using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.ViewModels.Tag;
using Dapper;
using System.Data;

namespace Blog.Infra.Data.Repository;

public class TagRepository : Repository<Tag>, ITagRepository
{
    public TagRepository(IDbConnection db, IDbTransaction transaction) : base(db, transaction)
    {
    }

    public List<TagForShowViewModel> GetAllTags()
    {
        string query = "SELECT  [Id] AS [TagId], [TagName] " +
            "FROM[Tag].[Tags]";

        return Db.Query<TagForShowViewModel>(query, transaction: Transaction).ToList();
    }

    public UpdateTagViewModel? GetTagForUpdate(Guid tagId)
    {
        string query = "SELECT [Id] AS [TagId], [TagName] " +
            "FROM [Tag].[Tags] " +
            "WHERE [Id] = @TagId";

        return Db.QuerySingleOrDefault<UpdateTagViewModel>(query, new
        {
            TagId = tagId
        }, Transaction);
    }
}