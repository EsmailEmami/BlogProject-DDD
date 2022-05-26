using Blog.Domain.Common.Constants;
using Blog.Domain.Common.Extensions;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Events.Blog;
using Blog.Domain.Interfaces;
using MediatR;
using System.Drawing;

namespace Blog.Domain.EventHandlers;

public class BlogEventHandler :
    INotificationHandler<BlogRegisteredEvent>,
    INotificationHandler<BlogUpdatedEvent>,
    INotificationHandler<BLogDeletedEvent>
{
    private readonly IMediatorHandler _bus;
    private readonly IBlogRepository _blogRepository;
    private readonly IUnitOfWork _uow;

    public BlogEventHandler(IMediatorHandler bus, IBlogRepository blogRepository, IUnitOfWork uow)
    {
        _bus = bus;
        _blogRepository = blogRepository;
        _uow = uow;
    }

    public Task Handle(BlogRegisteredEvent notification, CancellationToken cancellationToken)
    {
        try
        {
            Image image = ImageExtension.Base64ToImage(notification.ImageBase64String);
            image.AddImage(notification.ImageName, PathConstant.BlogImageServer);

            return Task.CompletedTask;
        }
        catch
        {
            Models.Blog? blog = _blogRepository.GetById(notification.BlogId);

            if (blog != null)
            {
                _blogRepository.Delete(blog);
                _uow.Commit();
            }

            _bus.RaiseEvent(new DomainNotification("image not found error", "تصویر یافت نشد"));
            return Task.FromCanceled(cancellationToken);
        }
    }

    public Task Handle(BlogUpdatedEvent notification, CancellationToken cancellationToken)
    {
        try
        {
            Image image = ImageExtension.Base64ToImage(notification.ImageBase64String);
            image.AddImage(notification.ImageName, PathConstant.BlogImageServer, notification.LastImageName);
            return Task.CompletedTask;
        }
        catch
        {
            _bus.RaiseEvent(new DomainNotification("image not found error", "تصویر یافت نشد"));
            return Task.FromCanceled(cancellationToken);
        }
    }

    public Task Handle(BLogDeletedEvent notification, CancellationToken cancellationToken)
    {
        ImageExtension.DeleteImage(notification.ImageName);
        return Task.CompletedTask;
    }
}