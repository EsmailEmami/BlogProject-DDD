namespace Blog.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    bool Commit();
}