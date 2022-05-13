using System.Drawing;
using System.Text.Json;
using Blog.Domain.Common.Constants;
using Blog.Domain.Common.Extensions;
using Blog.Domain.Events.Blog;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Blog.Domain.EventHandlers;

public class BlogEventHandler :
    INotificationHandler<BlogRegisteredEvent>,
    INotificationHandler<BlogUpdatedEvent>,
    INotificationHandler<BLogDeletedEvent>
{
    public Task Handle(BlogRegisteredEvent notification, CancellationToken cancellationToken)
    {
        Image image = ImageExtension.Base64ToImage(notification.ImageBase64String);
        image.AddImage(notification.ImageName, PathConstant.BlogImageServer);
        return Task.CompletedTask;
    }

    public Task Handle(BlogUpdatedEvent notification, CancellationToken cancellationToken)
    {
        Image image = ImageExtension.Base64ToImage(notification.ImageBase64String);
        image.AddImage(notification.ImageName, PathConstant.BlogImageServer, notification.LastImageName);

        return Task.CompletedTask;
    }

    public Task Handle(BLogDeletedEvent notification, CancellationToken cancellationToken)
    {
        ImageExtension.DeleteImage(notification.ImageName);
        return Task.CompletedTask;
    }
}