using Blog.Domain.Common.Exceptions;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Queries.Category;
using Blog.Domain.ViewModels.Category;
using MediatR;

namespace Blog.Domain.QueryHandlers;

public class CategoryQueryHandler : QueryHandler,
    IRequestHandler<GetCategoryForUpdateQuery, UpdateCategoryViewModel>,
    IRequestHandler<GetAllCategoriesQuery, List<CategoryForShowViewModel>>,
    IRequestHandler<GetBlogCategoriesQuery, List<CategoryForShowViewModel>>
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryQueryHandler(IMediatorHandler bus, ICategoryRepository categoryRepository) : base(bus)
    {
        _categoryRepository = categoryRepository;
    }

    public Task<UpdateCategoryViewModel> Handle(GetCategoryForUpdateQuery request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        UpdateCategoryViewModel? category = _categoryRepository.GetCategoryForUpdate(request.Id);

        if (category != null) return Task.FromResult(category);

        Bus.RaiseEvent(new DomainNotification("category not found", "دسته بندی مورد نظر یافت نشد"));
        throw new EntityNotFoundException();
    }

    public Task<List<CategoryForShowViewModel>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        List<CategoryForShowViewModel> categories = _categoryRepository.GetAllCategories();
        return Task.FromResult(categories);
    }

    public Task<List<CategoryForShowViewModel>> Handle(GetBlogCategoriesQuery request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        List<CategoryForShowViewModel> categories = _categoryRepository.GetBlogCategories(request.BlogId);
        return Task.FromResult(categories);
    }
}