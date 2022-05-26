using Blog.Domain.Common.Extensions;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Queries.BlogTag;
using MediatR;

namespace Blog.Domain.QueryHandlers;

public class BlogTagQueryHandler : QueryHandler,
    IRequestHandler<GetBlogTagsIdByBlogQuery, List<Guid>>
{
    private readonly IBlogTagRepository _blogTagRepository;

    public BlogTagQueryHandler(IMediatorHandler bus, IBlogTagRepository blogTagRepository) : base(bus)
    {
        _blogTagRepository = blogTagRepository;
    }

    public Task<List<Guid>> Handle(GetBlogTagsIdByBlogQuery request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        List<Guid>? blogTags = _blogTagRepository.GetBlogTagsIdByBlog(request.BlogId);

        if (blogTags == null)
        {
            Bus.RaiseEvent(new DomainNotification("category not found", "تگ یافت نشد"));
            return Task.FromResult(new List<Guid>());
        }

        return Task.FromResult(blogTags);
    }
}