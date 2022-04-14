using Blog.Domain.Core.Events;
using Blog.Infra.Data.Context;

namespace Blog.Infra.Data.Repository.EventSourcing;

public class EventStoreSqlRepository : IEventStoreRepository
{
    private readonly EventStoreSqlContext _context;

    public EventStoreSqlRepository(EventStoreSqlContext context)
    {
        _context = context;
    }

    public void Store(StoredEvent theEvent)
    {
        _context.StoredEvent.Add(theEvent);
        _context.SaveChanges();
    }

    public IList<StoredEvent> All(Guid aggregateId)
    {
        return _context.StoredEvent.Where(x => x.AggregateId == aggregateId).ToList();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}