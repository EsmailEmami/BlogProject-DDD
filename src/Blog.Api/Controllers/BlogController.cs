﻿using Blog.Application.Interfaces;
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

    [HttpGet("[action]")]
    public IActionResult GetAll()
    {
        return Response(_blogAppService.GetAllBlogs());
    }

    [HttpPost("AddBlog")]
    public async Task<IActionResult> AddBlog([FromBody] BlogViewModel blog)
    {
        if (!ModelState.IsValid)
        {
            NotifyModelStateErrors();
            return Response(blog);
        }

        Guid blogId = await _blogAppService.Register(blog);
        blog.Id = blogId;

        return Response(blogId);
    }
}