using Blog.Domain.Commands.Category;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using FluentValidation.Results;
using MediatR;

namespace Blog.Domain.CommandHandlers;

public class CategoryCommandHandler : CommandHandler,
    IRequestHandler<RegisterNewCategoryCommand, Guid>,
    IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMediatorHandler _bus;
    public CategoryCommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications, ICategoryRepository categoryRepository) : base(uow, bus, notifications)
    {
        _bus = bus;
        _categoryRepository = categoryRepository;
    }

    public Task<Guid> Handle(RegisterNewCategoryCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(Guid.Empty);
        }

        Category category = new Category(Guid.NewGuid(), request.CategoryTitle);
        _categoryRepository.Add(category);
        Commit();

        return Task.FromResult(category.Id);
    }

    public Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        Category category = new Category(request.Id, request.CategoryTitle);
        Category existingCategory = _categoryRepository.GetById(request.Id);

        if (existingCategory.Id != category.Id)
        {
            if (!existingCategory.Equals(category))
            {
                _bus.RaiseEvent(new DomainNotification(request.MessageType, "دسته بندی مورد نظر در سیستم موجود است."));
                return Task.FromResult(false);
            }
        }

        _categoryRepository.Update(category);
        Commit();
        return Task.FromResult(true);
    }
}