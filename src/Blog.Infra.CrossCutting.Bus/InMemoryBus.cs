using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Commands;
using Blog.Domain.Core.Events;
using Blog.Domain.Core.Notifications;
using MediatR;

namespace Blog.Infra.CrossCutting.Bus;

public class InMemoryBus : IMediatorHandler
{
    private readonly IMediator _mediator;
    private readonly IEventStore _eventStore;

    public InMemoryBus(IEventStore eventStore, IMediator mediator)
    {
        _eventStore = eventStore;
        _mediator = mediator;
    }

    public Task SendCommand<T>(T command) where T : Command => _mediator.Send(command);

    public Task RaiseEvent<T>(T @event) where T : Event
    {
        if (!@event.MessageType.Equals(nameof(DomainNotification)))
            _eventStore.Save(@event);

        return _mediator.Publish(@event);
    }
}