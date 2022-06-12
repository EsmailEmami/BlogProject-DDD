using Blog.Application.Interfaces;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.ViewModels.Tag;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

    [HttpGet("tags")]
    [ProducesResponseType(typeof(List<TagForShowViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Tags()
    {
        List<TagForShowViewModel> tags = await _tagAppService.GetAllTagsAsync();
        return Response(tags);
    }

    [HttpPost("add-tag")]
    public IActionResult AddTag([FromBody] AddTagViewModel tag)
    {
        _tagAppService.AddTag(tag);
        return Response();
    }

    [HttpGet("get-tag-for-update")]
    [ProducesResponseType(typeof(UpdateTagViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetTagForUpdate([FromQuery] Guid tagId)
    {
        UpdateTagViewModel? tag = await _tagAppService.GetTagForUpdateAsync(tagId);

        return Response(tag);
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

    [HttpGet("blog-tags")]
    public async Task<IActionResult> BlogTags([FromQuery] Guid blogId)
    {
        return Response(await _tagAppService.GetBlogTags(blogId));
    }
}