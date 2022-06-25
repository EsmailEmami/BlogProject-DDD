using Blog.Domain.Commands.Category;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using MediatR;
using System.Data.SqlClient;
using Blog.Domain.ViewModels.Category;

namespace Blog.Domain.CommandHandlers;

public class CategoryCommandHandler : CommandHandler,
    IRequestHandler<RegisterNewCategoryCommand, CategoryForShowViewModel>,
    IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryCommandHandler(IMediatorHandler bus, ICategoryRepository categoryRepository) : base(bus)
    {
        _categoryRepository = categoryRepository;
    }

    public Task<CategoryForShowViewModel> Handle(RegisterNewCategoryCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        Category category = new Category(Guid.NewGuid(), request.CategoryTitle);

        try
        {
            _categoryRepository.Add(category);
        }
        catch (SqlException error)
        {
            if (error.Number == 2601)
            {
                Bus.RaiseEvent(new DomainNotification("index errror from SQL", "نام دسته بندی وارد شده ثبت شده است"));
            }

            throw;
        }

        return Task.FromResult(new CategoryForShowViewModel { CategoryId = category.Id, CategoryTitle = category.CategoryTitle });
    }

    public Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        Category category = new Category(request.Id, request.CategoryTitle);
        Category? existingCategory = _categoryRepository.GetById(request.Id);

        if (existingCategory == null)
        {
            Bus.RaiseEvent(new DomainNotification(request.MessageType, "دسته بندی مورد نظر در سیستم یافت نشد."));
            return Task.FromResult(false);
        }

        if (existingCategory.Id != category.Id)
        {
            if (!existingCategory.Equals(category))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "دسته بندی مورد نظر در سیستم موجود است."));
                return Task.FromResult(false);
            }
        }

        _categoryRepository.Update(category);

        return Task.FromResult(true);
    }
}