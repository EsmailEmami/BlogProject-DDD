using Blog.Domain.Core.Commands;
using Blog.Domain.Core.Events;

namespace Blog.Domain.Core.Bus;

public interface IMediatorHandler
{
    Task SendCommand<T>(T command) where T : Command;
    Task RaiseEvent<T>(T @event) where T : Event;
}