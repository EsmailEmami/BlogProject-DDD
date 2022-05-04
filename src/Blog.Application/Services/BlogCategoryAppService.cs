using AutoMapper;
using Blog.Application.Interfaces;
using Blog.Domain.Commands.BlogCategory;
using Blog.Domain.Core.Bus;
using Blog.Domain.ViewModels.BlogCategory;

namespace Blog.Application.Services;

public class BlogCategoryAppService : IBlogCategoryAppService
{
    private readonly IMapper _mapper;
    private readonly IMediatorHandler _bus;

    public BlogCategoryAppService(IMapper mapper, IMediatorHandler bus)
    {
        _mapper = mapper;
        _bus = bus;
    }

    public void AddBlogCategory(AddBlogCategoryViewModel blogCategory)
    {
        RegisterNewBlogCategoryCommand command = _mapper.Map<RegisterNewBlogCategoryCommand>(blogCategory);
        _bus.SendCommand<RegisterNewBlogCategoryCommand, Guid>(command);
    }
    public void Dispose() => GC.SuppressFinalize(this);
}