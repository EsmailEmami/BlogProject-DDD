using Blog.Application.Interfaces;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
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
    public IActionResult AddRole([FromBody] string roleName)
    {
        _roleAppService.AddRoleAsync(roleName);
        return Response();
    }
}