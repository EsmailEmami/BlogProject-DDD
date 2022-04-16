using Blog.Application.Interfaces;
using Blog.Domain.Common.Extensions;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.ViewModels.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Blog.Services.Api.Controllers;

public class UserController : ApiController
{
    #region constructor

    private readonly IUserAppService _userAppService;
    private readonly IUser _user;
    public UserController(INotificationHandler<DomainNotification> notifications,
        IMediatorHandler mediator,
        IUser user,
        IUserAppService userAppService) : base(notifications, mediator)
    {
        _user = user;
        _userAppService = userAppService;
    }

    #endregion

    #region Dashboard

    [HttpGet("dashboard")]
    public IActionResult Dashboard()
    {
        Guid userId = _user.UserId;
        if (userId.IsEmpty())
        {
            NotifyError(HttpStatusCode.NotFound.ToString(), "کاربر مورد نظر یافت نشد.");
            return Response();
        }

        DashboardViewModel? dashboard = _userAppService.GetUserDashboard(userId);
        if (dashboard == null)
        {
            NotifyError(HttpStatusCode.NotFound.ToString(), "کاربر مورد نظر یافت نشد.");
            return Response();
        }

        return Response(dashboard);
    }

    #endregion

    #region update dashboard

    [HttpPut("update-dashboard")]
    public IActionResult UpdateDashboard([FromBody] DashboardViewModel dashboard)
    {
        if (!ModelState.IsValid)
        {
            NotifyModelStateErrors();
            return Response();
        }

        Guid userId = _user.UserId;
        if (userId.IsEmpty())
        {
            NotifyError(HttpStatusCode.NotFound.ToString(), "کاربر مورد نظر یافت نشد.");
            return Response();
        }

        UpdateUserViewModel update = new UpdateUserViewModel()
        {
            Id = userId,
            FirstName = dashboard.FirstName,
            LastName = dashboard.LastName,
            Email = dashboard.Email
        };

        _userAppService.Update(update);
        return Response();
    }

    #endregion
}