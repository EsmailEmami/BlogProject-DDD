using Blog.Domain.Commands.BlogCategory;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using MediatR;
using System.Data.SqlClient;

namespace Blog.Domain.CommandHandlers;

public class BlogCategoryCommandHandler : CommandHandler,
    IRequestHandler<RegisterNewBlogCategoryCommand, bool>,
    IRequestHandler<RemoveBlogCategoryCommand, bool>
{
    private readonly IBlogCategoryRepository _blogCategoryRepository;
    public BlogCategoryCommandHandler(IMediatorHandler bus, IBlogCategoryRepository blogCategoryRepository) : base(bus)
    {
        _blogCategoryRepository = blogCategoryRepository;
    }

    public Task<bool> Handle(RegisterNewBlogCategoryCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        BlogCategory blogCategory = new BlogCategory(Guid.NewGuid(), request.BlogId, request.CategoryId);

        try
        {
            _blogCategoryRepository.Add(blogCategory);
        }
        catch (SqlException exception)
        {
            if (exception.Number == 547)
            {
                Bus.RaiseEvent(new DomainNotification("SQL Exception", "متاسفانه هنگام ثبت دسته بندی های مقاله به مشکلی غیر منتظره برخوردیم."));
                throw;
            }
        }

        return Task.FromResult(true);
    }

    public Task<bool> Handle(RemoveBlogCategoryCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        BlogCategory? blogCategory = _blogCategoryRepository.GetById(request.Id);

        if (blogCategory == null)
        {
            Bus.RaiseEvent(new DomainNotification("blog category not found", "دسته بندی یافت نشد"));
            return Task.FromResult(false);
        }

        _blogCategoryRepository.Delete(blogCategory);
        return Task.FromResult(true);
    }
}