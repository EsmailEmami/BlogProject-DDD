using Blog.Domain.Core.Commands;
using Blog.Domain.Core.Events;
using Blog.Domain.Core.Query;

namespace Blog.Domain.Core.Bus;

public interface IMediatorHandler
{
    Task<TResult> SendCommand<TCommand, TResult>(TCommand command) where TCommand : Command<TResult>;
    Task<TResult> SendQuery<TQuery, TResult>(TQuery query) where TQuery : Query<TResult>;
    Task RaiseEvent<TEvent>(TEvent @event) where TEvent : Event;
}