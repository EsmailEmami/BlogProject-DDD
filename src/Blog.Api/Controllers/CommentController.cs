using Blog.Application.Interfaces;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Services.Api.Controllers;

public class CommentController : ApiController
{
    private readonly ICommentAppService _commentAppService;
    public CommentController(
        INotificationHandler<DomainNotification> notifications,
        IMediatorHandler mediator, ICommentAppService commentAppService) : base(notifications, mediator)
    {
        _commentAppService = commentAppService;
    }

    [HttpGet("blog-comments")]
    public async Task<IActionResult> BlogComments([FromQuery] Guid blogId)
    {
        return Response(await _commentAppService.GetBlogCommentsAsync(blogId));
    }
}

