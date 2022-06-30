using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Services.Api.Controllers;

public class HomeController:ApiController
{
    public HomeController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator) : base(notifications, mediator)
    {
    }

    [HttpGet]
    [HttpPut]
    [HttpPost]
    [HttpDelete]
    [Route("/error")]
    public IActionResult HandleError()
    {
        return Response();
    }
}