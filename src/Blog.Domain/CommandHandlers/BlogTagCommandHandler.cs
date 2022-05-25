using Blog.Domain.Commands.BlogTag;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using MediatR;

namespace Blog.Domain.CommandHandlers;

public class BlogTagCommandHandler : CommandHandler,
    IRequestHandler<RegisterNewBlogTagCommand, bool>
{
    private readonly IBlogTagRepository _blogTagRepository;
    public BlogTagCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications, IBlogTagRepository blogTagRepository) : base(uow, bus, notifications)
    {
        _blogTagRepository = blogTagRepository;
    }

    public Task<bool> Handle(RegisterNewBlogTagCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        BlogTag blogTag = new BlogTag(Guid.NewGuid(), request.BlogId, request.TagId);
        _blogTagRepository.Add(blogTag);
        Commit();
        return Task.FromResult(true);
    }
}