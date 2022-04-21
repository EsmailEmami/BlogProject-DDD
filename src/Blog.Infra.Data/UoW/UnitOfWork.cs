using Blog.Domain.Interfaces;
using System.Data;

namespace Blog.Infra.Data.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDbTransaction _dbTransaction;

    public UnitOfWork(IDbTransaction dbTransaction)
    {
        _dbTransaction = dbTransaction;
    }

    public bool Commit()
    {
        try
        {
            _dbTransaction.Commit();
            // By adding this we can have muliple transactions as part of a single request
            _dbTransaction.Connection?.BeginTransaction();

            return true;
        }
        catch
        {
            _dbTransaction.Rollback();
            return false;
        }
    }

    public void Dispose()
    {
        //Close the SQL Connection and dispose the objects
        _dbTransaction.Connection?.Close();
        _dbTransaction.Connection?.Dispose();
        _dbTransaction.Dispose();
    }
}