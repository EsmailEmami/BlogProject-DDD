using Blog.Domain.Commands.Blog;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Events.Blog;
using Blog.Domain.Interfaces;
using MediatR;

namespace Blog.Domain.CommandHandlers;

public class BlogCommandHandler : CommandHandler,
    IRequestHandler<RegisterNewBlogCommand, Guid>,
    IRequestHandler<RemoveBlogCommand, bool>,
    IRequestHandler<UpdateBlogCommand, bool>
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMediatorHandler _bus;

    public BlogCommandHandler(
        IUnitOfWork uow,
        IMediatorHandler bus,
        INotificationHandler<DomainNotification> notifications,
        IBlogRepository blogRepository) : base(uow, bus, notifications)
    {
        _bus = bus;
        _blogRepository = blogRepository;
    }

    public Task<Guid> Handle(RegisterNewBlogCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(Guid.Empty);
        }

        Models.Blog blog = new Models.Blog(Guid.NewGuid(), request.AuthorId, request.BlogTitle, request.Summary,
            request.Description, request.ImageFile, request.ReadTime);

        _blogRepository.Add(blog);

        if (Commit())
        {
            _bus.RaiseEvent(new BlogRegisteredEvent(blog.Id, blog.BlogTitle));
        }

        return Task.FromResult(blog.Id);
    }

    public Task<bool> Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        Models.Blog blog = _blogRepository.GetById(request.Id);

        if (blog.Id != request.Id)
        {
            _bus.RaiseEvent(new DomainNotification(request.MessageType, "کاربر مورد نظر یافت نشد."));
        }

        _blogRepository.Delete(blog);

        if (Commit())
        {
            //_bus.RaiseEvent(new BlogRemovedEvent(request.Id));
        }

        return Task.FromResult(true);
    }

    public Task<bool> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        Models.Blog blog = new Models.Blog(request.Id, request.AuthorId, request.BlogTitle, request.Summary,
            request.Description, request.ImageFile, request.ReadTime);

        Models.Blog existingBlog = _blogRepository.GetById(request.Id);

        if (existingBlog.Id != blog.Id)
        {
            if (!existingBlog.Equals(blog))
            {
                _bus.RaiseEvent(new DomainNotification(request.MessageType, "The blog has already been taken."));
                return Task.FromResult(false);
            }
        }

        _blogRepository.Update(blog);

        if (Commit())
        {
            _bus.RaiseEvent(new BlogUpdatedEvent(blog.Id, blog.BlogTitle));
        }

        return Task.FromResult(true);
    }
}