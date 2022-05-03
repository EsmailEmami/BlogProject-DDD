using Blog.Domain.Commands.BlogCategory;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using MediatR;

namespace Blog.Domain.CommandHandlers;

public class BlogCategoryCommandHandler : CommandHandler,
    IRequestHandler<RegisterNewBlogCategoryCommand, Guid>
{
    private readonly IBlogCategoryRepository _blogCategoryRepository;
    private readonly IBlogRepository _blogRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMediatorHandler _bus;
    public BlogCategoryCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications, IBlogCategoryRepository blogCategoryRepository, IBlogRepository blogRepository, ICategoryRepository categoryRepository) : base(uow, bus, notifications)
    {
        _bus = bus;
        _blogCategoryRepository = blogCategoryRepository;
        _blogRepository = blogRepository;
        _categoryRepository = categoryRepository;
    }

    public Task<Guid> Handle(RegisterNewBlogCategoryCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(Guid.Empty);
        }

        if (_blogRepository.IsBlogExist(request.BlogId))
        {
            _bus.RaiseEvent(new DomainNotification("BlogNotExist", "مقاله مورد نظر یافت نشد."));
        }

        if (_categoryRepository.IsCategoryExist(request.CategoryId))
        {
            _bus.RaiseEvent(new DomainNotification("CategoryNotExist", "دسته بندی مورد نظر یافت نشد."));
        }

        BlogCategory blogCategory = new BlogCategory(Guid.NewGuid(), request.BlogId, request.CategoryId);
        _blogCategoryRepository.Add(blogCategory);
        Commit();

        return Task.FromResult(blogCategory.Id);
    }
}