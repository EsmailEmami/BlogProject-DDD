using Blog.Application.Interfaces;
using Blog.Application.SignalR;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.ViewModels.Comment;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Blog.Services.Api.Controllers;

[Authorize]
public class CommentController : ApiController
{
    private readonly IUser _user;
    private readonly ICommentAppService _commentAppService;
    private readonly IHubContext<CommentHub> _commentHubContext;

    public CommentController(
        INotificationHandler<DomainNotification> notifications,
        IMediatorHandler mediator, ICommentAppService commentAppService,
        IUser user, IHubContext<CommentHub> commentHubContext) : base(notifications, mediator)
    {
        _commentAppService = commentAppService;
        _user = user;
        _commentHubContext = commentHubContext;
    }

    [HttpPost("add-comment")]
    public async Task<IActionResult> AddComment([FromBody] AddCommentViewModel comment)
    {
        comment.UserId = _user.UserId;

        CommentForShowViewModel insertedComment = await _commentAppService.AddCommentAsync(comment);

        if (IsValidOperation())
        {
            await _commentHubContext.Clients.Group(comment.BlogId.ToString()).SendAsync("ReceiveNewComment", insertedComment);
        }

        return Response();
    }

    [HttpGet("blog-comments")]
    public async Task<IActionResult> BlogComments([FromQuery] Guid blogId)
    {
        return Response(await _commentAppService.GetBlogCommentsAsync(blogId));
    }
}

