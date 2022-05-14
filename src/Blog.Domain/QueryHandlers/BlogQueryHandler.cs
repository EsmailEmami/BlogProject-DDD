using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Queries.Blog;
using Blog.Domain.ViewModels.Blog;
using MediatR;

namespace Blog.Domain.QueryHandlers;

public class BlogQueryHandler : QueryHandler,
    IRequestHandler<GetBlogForUpdateQuery, UpdateBlogViewModel>
{
    private readonly IBlogRepository _blogRepository;
    public BlogQueryHandler(IMediatorHandler bus, IBlogRepository blogRepository) : base(bus)
    {
        _blogRepository = blogRepository;
    }

    public Task<UpdateBlogViewModel> Handle(GetBlogForUpdateQuery request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(new UpdateBlogViewModel());
        }

        UpdateBlogViewModel blog = _blogRepository.GetBlogForUpdate(request.Id);

        if (blog == null)
        {
            Bus.RaiseEvent(new DomainNotification("blog not found", "مقاله مورد نظر یافت نشد"));

            return Task.FromResult(new UpdateBlogViewModel());
        }

        return Task.FromResult(blog);
    }
}