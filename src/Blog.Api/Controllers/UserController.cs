using Blog.Application.Interfaces;
using Blog.Domain.Common.Extensions;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.ViewModels.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Services.Api.Controllers;

[Authorize]
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
    public async Task<IActionResult> Dashboard()
    {
        Guid userId = _user.UserId;
        if (userId.IsEmpty())
        {
            NotifyError(HttpStatusCode.NotFound.ToString(), "کاربر مورد نظر یافت نشد.");
            return Response();
        }

        DashboardViewModel? dashboard = await _userAppService.GetUserDashboardAsync(userId);

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

    #region update password

    [HttpPut("update-password")]
    public IActionResult UpdatePassword([FromBody] UpdateUserPasswordViewModel userData)
    {
        userData.UserId = _user.UserId; 
        _userAppService.UpdateUserPassword(userData);
        return Response();
    }
    #endregion
}