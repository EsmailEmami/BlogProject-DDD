using Blog.Domain.Common.Exceptions;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Queries.Blog;
using Blog.Domain.ViewModels.Blog;
using MediatR;

namespace Blog.Domain.QueryHandlers;

public class BlogQueryHandler : QueryHandler,
    IRequestHandler<GetBlogForUpdateQuery, UpdateBlogViewModel>,
    IRequestHandler<GetAuthorBlogsQuery, List<BlogForShowViewModel>>,
    IRequestHandler<GetBlogsQuery, List<BlogForShowViewModel>>,
    IRequestHandler<GetBlogDetailQuery, BlogDetailViewModel>
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
            throw new InvalidOperationException();
        }

        UpdateBlogViewModel? blog = _blogRepository.GetBlogForUpdate(request.Id);

        if (blog == null)
        {
            Bus.RaiseEvent(new DomainNotification("blog not found", "مقاله مورد نظر یافت نشد"));
            throw new EntityNotFoundException();
        }

        return Task.FromResult(blog);
    }

    public Task<List<BlogForShowViewModel>> Handle(GetAuthorBlogsQuery request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        List<BlogForShowViewModel> blogs = _blogRepository.GetAuthorBlogs(request.AuthorId);

        return Task.FromResult(blogs);
    }

    public Task<List<BlogForShowViewModel>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_blogRepository.GetBlogs());
    }

    public Task<BlogDetailViewModel> Handle(GetBlogDetailQuery request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        BlogDetailViewModel blog = _blogRepository.GetBlogDetail(request.Id);

        if (blog == null)
        {
            Bus.RaiseEvent(new DomainNotification("blog not found", "مقاله مورد نظر یافت نشد."));
            throw new EntityNotFoundException();
        }

        return Task.FromResult(blog);
    }
}