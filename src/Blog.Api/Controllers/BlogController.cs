using Blog.Application.Interfaces;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Blog.Application.ViewModels.Blog;

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
    public IActionResult Post([FromBody] BlogViewModel customerViewModel)
    {
        if (!ModelState.IsValid)
        {
            NotifyModelStateErrors();
            return Response(customerViewModel);
        }

        _blogAppService.Register(customerViewModel);

        return Response(customerViewModel);
    }
}