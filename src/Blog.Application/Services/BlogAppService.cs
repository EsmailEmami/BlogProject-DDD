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

    public UpdateBlogViewModel? TestQuery()
    {
        GetBlogForUpdateQuery query = new GetBlogForUpdateQuery(Guid.Empty);

        try
        {
            return _bus.SendQuery<GetBlogForUpdateQuery, UpdateBlogViewModel>(query).Result;
        }
        catch
        {
            return null;
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}