using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Commands;
using Blog.Domain.Core.Events;
using Blog.Domain.Core.Notifications;
using MediatR;

namespace Blog.Infra.CrossCutting.Bus;

public class InMemoryBus : IMediatorHandler
{
    private readonly IMediator _mediator;

    public InMemoryBus(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task SendCommand<T>(T command) where T : Command => _mediator.Send(command);

    public Task RaiseEvent<T>(T @event) where T : Event
    {
        return _mediator.Publish(@event);
    }
}