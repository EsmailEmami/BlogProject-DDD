using Blog.Application.Interfaces;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Models;
using Blog.Domain.ViewModels.Role;
using Blog.Domain.ViewModels.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Services.Api.Controllers;

public class RoleController : ApiController
{
    private readonly IRoleAppService _roleAppService;
    public RoleController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator, IRoleAppService roleAppService) : base(notifications, mediator)
    {
        _roleAppService = roleAppService;
    }

    [HttpGet("roles")]
    public async Task<IActionResult> Roles()
    {
        return Response(await _roleAppService.GetAllRolesAsync());
    }

    [HttpPost("add-role")]
    [Consumes("application/json")]
    public async Task<IActionResult> AddRole([FromBody] string roleName)
    {
        Guid roleId = await _roleAppService.AddRoleAsync(roleName);
        return Response(new Role(roleId, roleName));
    }

    [HttpGet("get-role-for-update")]
    public async Task<IActionResult> GetRoleForUpdate([FromQuery] Guid roleId)
    {
        UpdateRoleViewModel role = await _roleAppService.GetRoleForUpdateAsync(roleId);
        return Response(role);
    }
}