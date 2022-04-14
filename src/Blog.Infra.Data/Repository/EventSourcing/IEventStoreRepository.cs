using Blog.Domain.Core.Events;

namespace Blog.Infra.Data.Repository.EventSourcing;

public interface IEventStoreRepository : IDisposable
{
    void Store(StoredEvent theEvent);
    IList<StoredEvent> All(Guid aggregateId);
}