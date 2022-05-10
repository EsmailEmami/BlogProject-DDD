using AutoMapper;
using Blog.Application.Interfaces;
using Blog.Domain.Commands.Category;
using Blog.Domain.Core.Bus;
using Blog.Domain.Interfaces;
using Blog.Domain.ViewModels.Category;

namespace Blog.Application.Services;

public class CategoryAppService : ICategoryAppService
{
    private readonly IMapper _mapper;
    private readonly IMediatorHandler _bus;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryAppService(IMapper mapper, IMediatorHandler bus, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _bus = bus;
        _categoryRepository = categoryRepository;
    }

    public async Task<Guid> AddCategoryAsync(AddCategoryViewModel category)
    {
        RegisterNewCategoryCommand command = _mapper.Map<RegisterNewCategoryCommand>(category);
        return await _bus.SendCommand<RegisterNewCategoryCommand, Guid>(command);
    }

    public void UpdateCategory(UpdateCategoryViewModel category)
    {
        UpdateCategoryCommand command = _mapper.Map<UpdateCategoryCommand>(category);
        _bus.SendCommand<UpdateCategoryCommand, bool>(command);
    }

    public UpdateCategoryViewModel GetCategoryForUpdate(Guid categoryId) =>
        _categoryRepository.GetCategoryForUpdate(categoryId);

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}