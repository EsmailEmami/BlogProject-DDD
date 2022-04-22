using Blog.Domain.Core.Commands;
using Blog.Domain.Core.Events;

namespace Blog.Domain.Core.Bus;

public interface IMediatorHandler
{
    Task<TResult> SendCommand<TCommand, TResult>(TCommand command) where TCommand : Command<TResult>;
    Task RaiseEvent<TEvent>(TEvent @event) where TEvent : Event;
}