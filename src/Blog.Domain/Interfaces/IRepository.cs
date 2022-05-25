namespace Blog.Domain.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : class
{
    TEntity? GetById(Guid id);
    List<TEntity> GetAll();
    void Add(TEntity obj);
    void Update(TEntity obj);
    void Delete(TEntity obj);    
}