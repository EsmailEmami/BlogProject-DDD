using System.Data;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;

namespace Blog.Infra.Data.Repository;

public class TagRepository : Repository<Tag>, ITagRepository
{
    public TagRepository(IDbConnection db, IDbTransaction transaction) : base(db, transaction)
    {
    }
}