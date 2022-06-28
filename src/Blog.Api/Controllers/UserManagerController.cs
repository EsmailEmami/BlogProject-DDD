using Blog.Application.Interfaces;
using Blog.Application.ViewModels.User;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.ViewModels.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Services.Api.Controllers;

public class UserManagerController : ApiController
{
    private readonly IUserAppService _userAppService;
    private readonly IUserRoleAppService _userRoleAppService;
    public UserManagerController(
        INotificationHandler<DomainNotification> notifications,
        IMediatorHandler mediator, IUserAppService userAppService, IUserRoleAppService userRoleAppService) : base(notifications, mediator)
    {
        _userAppService = userAppService;
        _userRoleAppService = userRoleAppService;
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

    #region update user

    [HttpGet("get-user-for-update")]
    public async Task<IActionResult> GetUserForUpdate([FromQuery] Guid userId)
    {
        UpdateUserViewModel user = await _userAppService.GetUserForUpdateAsync(userId);
        return Response(user);
    }

    [HttpPut("update-user")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserViewModel user)
    {
        _userAppService.Update(user);
        if (!IsValidOperation()) return Response();

        foreach (Guid roleId in user.Roles)
        {
            bool result = await _userRoleAppService.AddUserRoleAsync(user.Id, roleId);
            if (!result)
                break;
        }

        return Response();
    }

    #endregion
}