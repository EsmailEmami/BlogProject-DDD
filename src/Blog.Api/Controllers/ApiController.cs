using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Blog.Services.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class ApiController : ControllerBase
{
    private readonly DomainNotificationHandler _notifications;
    private readonly IMediatorHandler _mediator;

    protected ApiController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator)
    {
        _notifications = (DomainNotificationHandler)notifications;
        _mediator = mediator;
    }

    protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

    protected bool IsValidOperation()
    {
        return (!_notifications.HasNotifications());
    }

    protected new IActionResult Response(object? result)
    {
        if (IsValidOperation())
        {
            return Ok(result);
        }

        return BadRequest(_notifications.GetNotifications().Select(n => n.Value).ToList());
    }

    protected new IActionResult Response()
    {
        if (IsValidOperation())
        {
            return Ok(new
            {
                success = true
            });
        }

        List<string> notificationKeys = _notifications.GetNotifications()
            .Select(n => n.Key)
            .ToList();

        if (notificationKeys.Contains(HttpStatusCode.BadRequest.ToString()) ||
            notificationKeys.Contains(nameof(DomainNotification)))
        {
            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => n.Value).ToList()
            });
        }

        return NotFound(new
        {
            success = false,
            errors = _notifications.GetNotifications().Select(n => n.Value).ToList()
        });
    }

    protected void NotifyModelStateErrors()
    {
        var errors = ModelState.Values.SelectMany(v => v.Errors);
        foreach (var error in errors)
        {
            var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
            NotifyError(HttpStatusCode.BadRequest.ToString(), errorMsg);
        }
    }

    protected void NotifyError(string code, string message)
    {
        _mediator.RaiseEvent(new DomainNotification(code, message));
    }

    protected void AddIdentityErrors(IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            NotifyError(result.ToString(), error.Description);
        }
    }
}