using System.Drawing;
using Blog.Application.Interfaces;
using Blog.Domain.Common.Constants;
using Blog.Domain.Common.Extensions;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.ViewModels.Blog;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Services.Api.Controllers;

public class BlogController : ApiController
{
    private readonly IBlogAppService _blogAppService;
    public BlogController(INotificationHandler<DomainNotification> notifications,
        IMediatorHandler mediator,
        IBlogAppService blogAppService) : base(notifications, mediator)
    {
        _blogAppService = blogAppService;
    }


    [HttpPost("add-blog")]
    public async Task<IActionResult> AddBlog([FromBody] AddBlogViewModel blog)
    {
        if (!ModelState.IsValid)
        {
            NotifyModelStateErrors();
            return Response(blog);
        }

        Guid blogId = await _blogAppService.Register(blog);

        return Response(blogId);
    }

    [HttpGet("get-blog-for-update")]
    public async Task<IActionResult> UpdateBlog([FromQuery] Guid blogId)
    {
        UpdateBlogViewModel? blog = await _blogAppService.GetBlogForUpdate(blogId);
        return Response(blog);
    }

    [HttpPut("update-blog")]
    public IActionResult UpdateBlog([FromBody] UpdateBlogViewModel blog)
    {
        if (!ModelState.IsValid)
        {
            NotifyModelStateErrors();
            return Response(blog);
        }

        _blogAppService.Update(blog);

        return Response();
    }
}