using Blog.Application.Interfaces;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.ViewModels.Blog;
using Blog.Domain.ViewModels.Tag;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Services.Api.Controllers;

public class TagController : ApiController
{
    private readonly ITagAppService _tagAppService;
    public TagController(INotificationHandler<DomainNotification> notifications,
        IMediatorHandler mediator,
        ITagAppService tagAppService) : base(notifications, mediator)
    {
        _tagAppService = tagAppService;
    }

    [HttpPost("add-tag")]
    public IActionResult AddTag([FromBody] AddTagViewModel tag)
    {
        _tagAppService.AddTag(tag);
        return Response();
    }

    [HttpPut("update-tag")]
    public IActionResult UpdateTag([FromBody] UpdateTagViewModel tag)
    {
        _tagAppService.UpdateTag(tag);
        return Response();
    }

    [HttpDelete("delete-tag")]
    public IActionResult DeleteTag([FromQuery] Guid tagId)
    {
        _tagAppService.DeleteTag(tagId);
        return Response();
    }
}