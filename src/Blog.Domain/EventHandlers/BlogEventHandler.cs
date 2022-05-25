using System.Drawing;
using System.Text.Json;
using Blog.Domain.Commands.BlogCategory;
using Blog.Domain.Commands.BlogTag;
using Blog.Domain.Commands.Tag;
using Blog.Domain.Common.Constants;
using Blog.Domain.Common.Extensions;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Events.Blog;
using Blog.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

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
        }
        catch
        {
            Models.Blog blog = _blogRepository.GetById(notification.BlogId);
            _blogRepository.Delete(blog);
            _uow.Commit();

            _bus.RaiseEvent(new DomainNotification("image not found error", "تصویر یافت نشد"));
            return Task.FromCanceled(cancellationToken);
        }

        foreach (Guid tag in notification.Tags)
        {
            RegisterNewBlogTagCommand blogTagCommand = new RegisterNewBlogTagCommand(notification.BlogId, tag);
            _bus.SendCommand<RegisterNewBlogTagCommand, bool>(blogTagCommand);
        }

        foreach (Guid category in notification.Categories)
        {
            RegisterNewBlogCategoryCommand blogCategory = new RegisterNewBlogCategoryCommand(notification.BlogId, category);
            _bus.SendCommand<RegisterNewBlogCategoryCommand, Guid>(blogCategory);
        }

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