using System.Security.Principal;
using Blog.Domain.Common.Exceptions;
using Blog.Domain.Common.Extensions;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Queries.BlogCategory;
using MediatR;

namespace Blog.Domain.QueryHandlers;

public class BlogCategoryQueryHandler : QueryHandler,
    IRequestHandler<GetBlogCategoriesIdByBlogQuery, List<Guid>>
{
    private readonly IBlogCategoryRepository _blogCategoryRepository;
    public BlogCategoryQueryHandler(IMediatorHandler bus, IBlogCategoryRepository blogCategoryRepository) : base(bus)
    {
        _blogCategoryRepository = blogCategoryRepository;
    }

    public Task<List<Guid>> Handle(GetBlogCategoriesIdByBlogQuery request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        List<Guid>? blogCategories = _blogCategoryRepository.GetBlogCategoriesIdByBlog(request.BlogId);

        if (blogCategories == null)
        {
            Bus.RaiseEvent(new DomainNotification("category not found", "دسته بندی یافت نشد"));
            return Task.FromResult(new List<Guid>());
        }

        return Task.FromResult(blogCategories);
    }
}