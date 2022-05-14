using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Commands;
using Blog.Domain.Core.Events;
using Blog.Domain.Core.Query;
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

    public Task<TResult> SendQuery<TQuery, TResult>(TQuery query) where TQuery : Query<TResult>
        => _mediator.Send(query);

    public Task RaiseEvent<TResult>(TResult @event) where TResult : Event => _mediator.Publish(@event);
}