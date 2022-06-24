using Blog.Domain.Commands.Blog;
using Blog.Domain.Common.Extensions;
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

    public BlogCommandHandler(
        IMediatorHandler bus,
        IBlogRepository blogRepository) : base(bus)
    {
        _blogRepository = blogRepository;
    }

    public Task<Guid> Handle(RegisterNewBlogCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(Guid.Empty);
        }

        string imageFile = Guid.NewGuid().ToString("N") + ".jpeg";

        Models.Blog blog = new Models.Blog(Guid.NewGuid(), request.AuthorId, request.BlogTitle, request.Summary,
            request.Description, imageFile, request.ReadTime);

        _blogRepository.Add(blog);

        Bus.RaiseEvent(new BlogRegisteredEvent(blog.Id, request.ImageFile, imageFile));

        return Task.FromResult(blog.Id);
    }

    public Task<bool> Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        Models.Blog? blog = _blogRepository.GetById(request.Id);

        if (blog == null)
        {
            Bus.RaiseEvent(new DomainNotification(request.MessageType, "مقاله مورد نظر یافت نشد."));
        }

        _blogRepository.Delete(blog);

        Bus.RaiseEvent(new BLogDeletedEvent(blog.ImageFile));

        return Task.FromResult(true);
    }

    public Task<bool> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        string imageFile = Guid.NewGuid().ToString("N") + ".jpeg";

        Models.Blog blog = new Models.Blog(request.Id, request.AuthorId, request.BlogTitle, request.Summary,
            request.Description, imageFile, request.ReadTime);

        Models.Blog? existingBlog = _blogRepository.GetById(request.Id);

        if (existingBlog == null)
        {
            Bus.RaiseEvent(new DomainNotification(request.MessageType, "مقاله مورد نظر یافت نشد."));
            return Task.FromResult(false);
        }

        blog.SetWrittenAt(existingBlog.WrittenAt);

        if (string.IsNullOrEmpty(request.ImageFile))
        {
            blog.SetImageFile(existingBlog.ImageFile);
        }

        if (existingBlog.Id != blog.Id)
        {
            if (!existingBlog.Equals(blog))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "مقاله مورد نظر ثبت شده است."));
                return Task.FromResult(false);
            }
        }

        _blogRepository.Update(blog);

        Bus.RaiseEvent(new BlogUpdatedEvent(blog.Id, request.ImageFile, imageFile, existingBlog.ImageFile));

        return Task.FromResult(true);
    }
}