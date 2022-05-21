﻿using Blog.Domain.Common.Exceptions;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Queries.Category;
using Blog.Domain.ViewModels.Category;
using MediatR;

namespace Blog.Domain.QueryHandlers;

public class CategoryQueryHandler : QueryHandler,
    IRequestHandler<GetCategoryForUpdateQuery, UpdateCategoryViewModel>
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
}