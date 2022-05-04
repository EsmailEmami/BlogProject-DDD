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

    public CategoryAppService(IMapper mapper, IMediatorHandler bus)
    {
        _mapper = mapper;
        _bus = bus;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task<Guid> AddCategoryAsync(AddCategoryViewModel category)
    {
        RegisterNewCategoryCommand command = _mapper.Map<RegisterNewCategoryCommand>(category);
        return await _bus.SendCommand<RegisterNewCategoryCommand, Guid>(command);
    }
}