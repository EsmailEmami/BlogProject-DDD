using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Commands;
using Blog.Domain.Core.Notifications;

namespace Blog.Domain.CommandHandlers;

public class CommandHandler
{
    protected readonly IMediatorHandler Bus;

    public CommandHandler(IMediatorHandler bus)
    {
        Bus = bus;
    }
    protected void NotifyValidationErrors<TCommand>(Command<TCommand> message)
    {
        foreach (var error in message.ValidationResult.Errors)
        {
            Bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
        }
    }
}