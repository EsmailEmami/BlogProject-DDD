using Blog.Application.Interfaces;
using Blog.Application.ViewModels.User;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;

namespace Blog.Services.Api.Controllers;

public class UserManagerController : ApiController
{
    private readonly IUserAppService _userAppService;
    public UserManagerController(
        INotificationHandler<DomainNotification> notifications,
        IMediatorHandler mediator, IUserAppService userAppService) : base(notifications, mediator)
    {
        _userAppService = userAppService;
    }

    #region Users

    [HttpGet("users")]
    public async Task<IActionResult> Users([FromQuery] int pageId, [FromQuery] int take, [FromQuery] string? search)
    {
        FilterUsersViewModel users = await _userAppService.GetUsers(pageId, take, search);
        return Response(users);
    }

    #endregion

    #region Admins

    [HttpGet("admins")]
    public async Task<IActionResult> Admins([FromQuery] int pageId, [FromQuery] int take, [FromQuery] string? search)
    {
        FilterUsersViewModel admins = await _userAppService.GetAdmins(pageId, take, search);
        return Response(admins);
    }

    #endregion
}