using System.Net;
using Blog.Application.Interfaces;
using Blog.Application.SignalR;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Models;
using Blog.Domain.ViewModels.User;
using Blog.Infra.CrossCutting.Identity.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using Blog.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Services.Api.Controllers;

public class AccountController : ApiController
{
    #region constructor

    private readonly IAccountAppService _accountAppService;
    private readonly IUserAppService _userAppService;
    private readonly IUserRoleAppService _userRoleAppService;
    private readonly IRoleAppService _roleAppService;
    private readonly IUser _user;
    private readonly IJwtFactory _jwtFactory;
    private readonly IHubContext<UserManagerHub> _userHub;

    public AccountController(INotificationHandler<DomainNotification> notifications,
        IMediatorHandler mediator,
        IAccountAppService accountAppService,
        IUserAppService userAppService,
        IJwtFactory jwtFactory,
        IHubContext<UserManagerHub> userHub,
        IUserRoleAppService userRoleAppService, IRoleAppService roleAppService, IUser user) : base(notifications, mediator)
    {
        _accountAppService = accountAppService;
        _userAppService = userAppService;
        _jwtFactory = jwtFactory;
        _userHub = userHub;
        _userRoleAppService = userRoleAppService;
        _roleAppService = roleAppService;
        _user = user;
    }

    #endregion

    #region register

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterViewModel register)
    {
        if (!ModelState.IsValid)
        {
            NotifyModelStateErrors();
            return Response(register);
        }

        UserForShowViewModel user = await _accountAppService.RegisterAsync(register);

        if (IsValidOperation())
        {
            await _userHub.Clients.All.SendAsync("ReceiveRegisteredUser", user);
        }

        return Response();
    }

    #endregion

    #region login

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginViewModel login)
    {
        if (!ModelState.IsValid)
        {
            NotifyModelStateErrors();
            return Response(login);
        }

        bool loginResult = await _accountAppService.LoginAsync(login);
        if (!loginResult) return Response();

        User? user = await _userAppService.GetUserByEmailAsync(login.Email);
        if (user == null) return Response();

        string token = await GenerateToken(user);

        return Response(new
        {
            id = user.Id,
            firstName = user.FirstName,
            lastName = user.LastName,
            email = user.Email,
            token
        });
    }

    #endregion

    #region Check Permission

    [Authorize]
    [HttpPost("check-permission")]
    public async Task<IActionResult> CheckUserPermission([FromBody] List<string> rolesName)
    {
        List<Guid> rolesId = await _roleAppService.GetRolesIdAsync(rolesName);
        List<Guid> userRolesId = await _userRoleAppService.GetAllUserRolesIdAsync(_user.UserId);

        bool result = true;

        foreach (Guid roleId in rolesId)
        {
            bool isValid = userRolesId.Contains(roleId);
            if (!isValid)
            {
                result = false;
                break;
            }
        }

        return Response(result);
    }

    #endregion

    #region private methods

    private async Task<string> GenerateToken(User user)
    {
        // Init ClaimsIdentity
        var claimsIdentity = new ClaimsIdentity();
        claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, user.Email));


        // Generate access token
        var jwtToken = await _jwtFactory.GenerateJwtToken(claimsIdentity);

        return jwtToken;
    }

    #endregion
}