using Blog.Domain.Interfaces;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Blog.Infra.Data.Repository;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly IDbConnection Db;

    protected Repository(IDbConnection db)
    {
        Db = db;
    }

    public TEntity? GetById(Guid id) => Db.Get<TEntity>(id);

    public List<TEntity> GetAll() => Db.GetAll<TEntity>().ToList();

    public void Add(TEntity obj) => Db.Insert(obj);

    public void Update(TEntity obj) => Db.Update(obj);

    public void Delete(TEntity obj) => Db.Delete(obj);

    public void Dispose()
    {
        Db.Dispose();
    }
}