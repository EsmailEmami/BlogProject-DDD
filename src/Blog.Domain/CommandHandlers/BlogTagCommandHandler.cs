using Blog.Domain.Commands.BlogCategory;
using Blog.Domain.Commands.BlogTag;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using MediatR;
using System.Data.SqlClient;

namespace Blog.Domain.CommandHandlers;

public class BlogTagCommandHandler : CommandHandler,
    IRequestHandler<RegisterNewBlogTagCommand, bool>,
    IRequestHandler<RemoveBlogTagCommand, bool>
{
    private readonly IBlogTagRepository _blogTagRepository;
    public BlogTagCommandHandler(IMediatorHandler bus, IBlogTagRepository blogTagRepository) : base(bus)
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

        try
        {
            _blogTagRepository.Add(blogTag);
        }
        catch (SqlException exception)
        {
            if (exception.Number == 547)
            {
                Bus.RaiseEvent(new DomainNotification("SQL Exception", "متاسفانه هنگام تگ های مقاله به مشکلی غیر منتظره برخوردیم."));
                throw exception;
            }
        }

        return Task.FromResult(true);
    }

    public Task<bool> Handle(RemoveBlogTagCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        BlogTag? blogTag = _blogTagRepository.GetById(request.Id);

        if (blogTag == null)
        {
            Bus.RaiseEvent(new DomainNotification("blog category not found", "دسته بندی یافت نشد"));
            return Task.FromResult(false);
        }

        _blogTagRepository.Delete(blogTag);
        return Task.FromResult(true);
    }
}