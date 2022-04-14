using Blog.Domain.Events.User;
using MediatR;

namespace Blog.Domain.EventHandlers;

public class UserEventHandler :
    INotificationHandler<UserRegisteredEvent>
{
    public Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}