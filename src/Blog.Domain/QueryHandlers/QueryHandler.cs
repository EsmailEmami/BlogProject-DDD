using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Core.Query;

namespace Blog.Domain.QueryHandlers;

public abstract class QueryHandler
{
    protected readonly IMediatorHandler Bus;

    protected QueryHandler(IMediatorHandler bus)
    {
        Bus = bus;
    }
    protected void NotifyValidationErrors<TQuery>(Query<TQuery> message)
    {
        foreach (var error in message.ValidationResult.Errors)
        {
            Bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
        }
    }
}
