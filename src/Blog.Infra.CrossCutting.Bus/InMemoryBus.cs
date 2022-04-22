using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Commands;
using Blog.Domain.Core.Events;
using MediatR;

namespace Blog.Infra.CrossCutting.Bus;

public class InMemoryBus : IMediatorHandler
{
    private readonly IMediator _mediator;

    public InMemoryBus(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public Task<TResult> SendCommand<TCommand, TResult>(TCommand command) where TCommand : Command<TResult> 
        => _mediator.Send(command);

    public Task RaiseEvent<TResult>(TResult @event) where TResult : Event => _mediator.Publish(@event);
}