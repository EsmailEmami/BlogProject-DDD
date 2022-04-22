using MediatR;

namespace Blog.Domain.Core.Events;

public abstract class Event : Message<bool>, INotification
{
    public DateTime Timestamp { get; private set; }
    protected Event()
    {
        Timestamp = DateTime.Now;
    }
}