using Blog.Application.Interfaces;
using Blog.Domain.ViewModels.User;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Models;
using Blog.Infra.CrossCutting.Identity.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using Blog.Application.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace Blog.Services.Api.Controllers;

public class AccountController : ApiController
{
    #region constructor

    private readonly IAccountAppService _accountAppService;
    private readonly IUserAppService _userAppService;
    private readonly IJwtFactory _jwtFactory;
    private readonly IHubContext<UserManagerHub> _userHub;

    public AccountController(INotificationHandler<DomainNotification> notifications,
        IMediatorHandler mediator,
        IAccountAppService accountAppService,
        IUserAppService userAppService,
        IJwtFactory jwtFactory,
        IHubContext<UserManagerHub> userHub) : base(notifications, mediator)
    {
        _accountAppService = accountAppService;
        _userAppService = userAppService;
        _jwtFactory = jwtFactory;
        _userHub = userHub;
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