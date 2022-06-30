using Blog.Application.Interfaces;
using Blog.Domain.Commands.BlogCategory;
using Blog.Domain.Core.Bus;
using Blog.Domain.Queries.BlogCategory;

namespace Blog.Application.Services;

public class BlogCategoryAppService : IBlogCategoryAppService
{
    private readonly IMediatorHandler _bus;

    public BlogCategoryAppService(IMediatorHandler bus)
    {
        _bus = bus;
    }

    public async Task<bool> AddBlogCategoryAsync(Guid blogId, Guid categoryId)
    {
        RegisterNewBlogCategoryCommand command = new RegisterNewBlogCategoryCommand(blogId, categoryId);
        return await _bus.SendCommand<RegisterNewBlogCategoryCommand, bool>(command);
    }


    public void DeleteBlogCategory(Guid blogCategoryId)
    {
        RemoveBlogCategoryCommand command = new RemoveBlogCategoryCommand(blogCategoryId);
        _bus.SendCommand<RemoveBlogCategoryCommand, bool>(command);
    }

    public async Task<List<Guid>> GetBlogCategories(Guid blogId)
    {
        GetBlogCategoriesIdByBlogQuery query = new GetBlogCategoriesIdByBlogQuery(blogId);
        return await _bus.SendQuery<GetBlogCategoriesIdByBlogQuery, List<Guid>>(query);
    }

    public void Dispose() => GC.SuppressFinalize(this);
}