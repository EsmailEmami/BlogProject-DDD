using AutoMapper;
using Blog.Application.Interfaces;
using Blog.Domain.Commands.Blog;
using Blog.Domain.Core.Bus;
using Blog.Domain.Interfaces;
using Blog.Domain.ViewModels.Blog;

namespace Blog.Application.Services;

public class BlogAppService : IBlogAppService
{
    private readonly IMapper _mapper;
    private readonly IBlogRepository _blogRepository;
    private readonly IMediatorHandler _bus;

    public BlogAppService(IMapper mapper, IBlogRepository blogRepository, IMediatorHandler bus)
    {
        _mapper = mapper;
        _blogRepository = blogRepository;
        _bus = bus;
    }

    public List<Domain.Models.Blog> GetAllBlogs() =>
        _blogRepository.GetAll().ToList();

    public async Task<Guid> Register(AddBlogViewModel blog)
    {
        RegisterNewBlogCommand registerCommand = _mapper.Map<RegisterNewBlogCommand>(blog);
        return await _bus.SendCommand<RegisterNewBlogCommand, Guid>(registerCommand);
    }

    public void Update(UpdateBlogViewModel blog)
    {
        UpdateBlogCommand updateCommand = _mapper.Map<UpdateBlogCommand>(blog);
        _bus.SendCommand<UpdateBlogCommand, bool>(updateCommand);
    }

    public void Remove(Guid blogId)
    {
        RemoveBlogCommand removeCommand = new RemoveBlogCommand(blogId);
        _bus.SendCommand<RemoveBlogCommand, bool>(removeCommand);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}