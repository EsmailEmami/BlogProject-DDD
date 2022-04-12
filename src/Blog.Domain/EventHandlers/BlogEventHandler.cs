using Blog.Domain.Events.Blog;
using MediatR;

namespace Blog.Domain.EventHandlers;

public class BlogEventHandler
: INotificationHandler<BlogRegisteredEvent>,
    INotificationHandler<BlogUpdatedEvent>
{
    public Task Handle(BlogRegisteredEvent notification, CancellationToken cancellationToken)
    {
        // do some thing

        return Task.CompletedTask;
    }

    public Task Handle(BlogUpdatedEvent notification, CancellationToken cancellationToken)
    {
        // Send some notification e-mail

        return Task.CompletedTask;
    }
}