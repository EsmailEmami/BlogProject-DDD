using AutoMapper;
using Blog.Application.Interfaces;
using Blog.Domain.Commands.Comment;
using Blog.Domain.Core.Bus;
using Blog.Domain.Queries.Comment;
using Blog.Domain.ViewModels.Comment;

namespace Blog.Application.Services;

public class CommentAppService : ICommentAppService
{
    private readonly IMapper _mapper;
    private readonly IMediatorHandler _bus;

    public CommentAppService(IMediatorHandler bus, IMapper mapper)
    {
        _bus = bus;
        _mapper = mapper;
    }

    public async Task<CommentForShowViewModel> AddCommentAsync(AddCommentViewModel comment)
    {
        RegisterNewCommentCommand command = _mapper.Map<RegisterNewCommentCommand>(comment);
        return await _bus.SendCommand<RegisterNewCommentCommand, CommentForShowViewModel>(command);
    }

    public async Task<List<CommentForShowViewModel>> GetBlogCommentsAsync(Guid blogId)
    {
        GetBlogCommentsQuery query = new GetBlogCommentsQuery(blogId);
        return await _bus.SendQuery<GetBlogCommentsQuery, List<CommentForShowViewModel>>(query);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}