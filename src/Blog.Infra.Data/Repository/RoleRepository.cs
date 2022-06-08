using System.Data;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;

namespace Blog.Infra.Data.Repository;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(IDbConnection db) : base(db)
    {
    }
}