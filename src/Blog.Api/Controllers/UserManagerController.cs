using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Services.Api.Controllers;

public class UserManagerController : ApiController
{
    public UserManagerController(
        INotificationHandler<DomainNotification> notifications,
        IMediatorHandler mediator) : base(notifications, mediator)
    {
    }

    #region Users

    [HttpGet("users")]
    public async Task<IActionResult> Users()
    {
        return null;
    }

    #endregion
}