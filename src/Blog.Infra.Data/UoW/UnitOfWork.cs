using Blog.Domain.Interfaces;
using Blog.Infra.Data.Context;

namespace Blog.Infra.Data.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public bool Commit()
    {
        return _context.SaveChanges() > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}