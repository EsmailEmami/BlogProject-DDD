using AutoMapper;
using Blog.Application.Interfaces;
using Blog.Domain.Commands.Blog;
using Blog.Domain.Common.Exceptions;
using Blog.Domain.Core.Bus;
using Blog.Domain.Interfaces;
using Blog.Domain.Queries.Blog;
using Blog.Domain.ViewModels.Blog;

namespace Blog.Application.Services;

public class BlogAppService : IBlogAppService
{
    private readonly IMapper _mapper;
    private readonly IMediatorHandler _bus;

    public BlogAppService(IMapper mapper, IMediatorHandler bus)
    {
        _mapper = mapper;
        _bus = bus;
    }

    public async Task<Guid> Register(AddBlogViewModel blog)
    {
        RegisterNewBlogCommand registerCommand = _mapper.Map<RegisterNewBlogCommand>(blog);
        return await _bus.SendCommand<RegisterNewBlogCommand, Guid>(registerCommand);
    }

    public void UpdateBlog(UpdateBlogViewModel blog)
    {
        UpdateBlogCommand updateCommand = _mapper.Map<UpdateBlogCommand>(blog);
        _bus.SendCommand<UpdateBlogCommand, bool>(updateCommand);
    }

    public void DeleteBlog(Guid blogId)
    {
        RemoveBlogCommand removeCommand = new RemoveBlogCommand(blogId);
        _bus.SendCommand<RemoveBlogCommand, bool>(removeCommand);
    }

    public async Task<UpdateBlogViewModel?> GetBlogForUpdate(Guid blogId)
    {
        GetBlogForUpdateQuery query = new GetBlogForUpdateQuery(blogId);
        return await _bus.SendQuery<GetBlogForUpdateQuery, UpdateBlogViewModel>(query);
    }

    public async Task<List<BlogForShowViewModel>> GetAuthorBlogs(Guid authorId)
    {
        GetAuthorBlogsQuery query = new GetAuthorBlogsQuery(authorId);
        return await _bus.SendQuery<GetAuthorBlogsQuery, List<BlogForShowViewModel>>(query);
    }

    public async Task<List<BlogForShowViewModel>> GetBlogs()
    {
        GetBlogsQuery query = new GetBlogsQuery();
        return await _bus.SendQuery<GetBlogsQuery, List<BlogForShowViewModel>>(query);
    }

    public async Task<BlogDetailViewModel?> GetBlogDetailAsync(Guid blogId)
    {
        GetBlogDetailQuery query = new GetBlogDetailQuery(blogId);
        return await _bus.SendQuery<GetBlogDetailQuery, BlogDetailViewModel>(query);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}