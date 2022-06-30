using AutoMapper;
using Blog.Application.Interfaces;
using Blog.Domain.Commands.Category;
using Blog.Domain.Core.Bus;
using Blog.Domain.Queries.Category;
using Blog.Domain.ViewModels.Category;

namespace Blog.Application.Services;

public class CategoryAppService : ICategoryAppService
{
    private readonly IMapper _mapper;
    private readonly IMediatorHandler _bus;

    public CategoryAppService(IMapper mapper, IMediatorHandler bus)
    {
        _mapper = mapper;
        _bus = bus;
    }

    public async Task<List<CategoryForShowViewModel>> GetAllCategoriesAsync()
    {
        GetAllCategoriesQuery query = new GetAllCategoriesQuery();

        return await _bus.SendQuery<GetAllCategoriesQuery, List<CategoryForShowViewModel>>(query);
    }
    public async Task<CategoryForShowViewModel> AddCategoryAsync(AddCategoryViewModel category)
    {
        RegisterNewCategoryCommand command = _mapper.Map<RegisterNewCategoryCommand>(category);
        return await _bus.SendCommand<RegisterNewCategoryCommand, CategoryForShowViewModel>(command);
    }

    public void UpdateCategory(UpdateCategoryViewModel category)
    {
        UpdateCategoryCommand command = _mapper.Map<UpdateCategoryCommand>(category);
        _bus.SendCommand<UpdateCategoryCommand, bool>(command);
    }

    public async Task<UpdateCategoryViewModel> GetCategoryForUpdate(Guid categoryId)
    {
        GetCategoryForUpdateQuery query = new GetCategoryForUpdateQuery(categoryId);
        return await _bus.SendQuery<GetCategoryForUpdateQuery, UpdateCategoryViewModel>(query);
    }

    public async Task<List<CategoryForShowViewModel>> GetBlogCategoriesAsync(Guid blogId)
    {
        GetBlogCategoriesQuery query = new GetBlogCategoriesQuery(blogId);
        return await _bus.SendQuery<GetBlogCategoriesQuery, List<CategoryForShowViewModel>>(query);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}