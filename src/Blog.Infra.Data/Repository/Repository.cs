using Blog.Domain.Interfaces;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Blog.Infra.Data.Repository;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly IDbConnection Db;
    protected readonly IDbTransaction Transaction;

    protected Repository(IDbConnection db, IDbTransaction transaction)
    {
        Db = db;
        Transaction = transaction;
    }


    public TEntity GetById(Guid id) => Db.Get<TEntity>(id);

    public List<TEntity> GetAll() => Db.GetAll<TEntity>().ToList();

    public void Add(TEntity obj) => Db.Insert(obj, Transaction);

    public void Update(TEntity obj) => Db.Update(obj, Transaction);

    public void Delete(TEntity obj) => Db.Delete(obj, Transaction);

    public bool Commit()
    {
        try
        {
            Transaction.Commit();

            return true;
        }
        catch
        {
            Transaction.Rollback();
            return false;
        }
    }

    public void Dispose()
    {
        Db.Dispose();
        Transaction.Dispose();
    }
}