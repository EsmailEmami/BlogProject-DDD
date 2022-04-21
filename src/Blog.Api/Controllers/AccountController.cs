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

namespace Blog.Services.Api.Controllers;

public class AccountController : ApiController
{
    #region constructor

    private readonly IAccountAppService _accountAppService;
    private readonly IUserAppService _userAppService;
    private readonly IJwtFactory _jwtFactory;

    public AccountController(INotificationHandler<DomainNotification> notifications,
        IMediatorHandler mediator,
        IAccountAppService accountAppService,
        IUserAppService userAppService,
        IJwtFactory jwtFactory) : base(notifications, mediator)
    {
        _accountAppService = accountAppService;
        _userAppService = userAppService;
        _jwtFactory = jwtFactory;
    }

    #endregion

    #region register

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterViewModel register)
    {
        if (!ModelState.IsValid)
        {
            NotifyModelStateErrors();
            return Response(register);
        }

        _accountAppService.Register(register);

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

        bool loginResult = _accountAppService.Login(login);
        if (!loginResult)
        {
            NotifyError(HttpStatusCode.NotFound.ToString(), "کاربری با مشخصات وارد شده یافت نشد.");
            return Response();
        }

        User? user = _userAppService.GetUserByEmail(login.Email);
        if (user == null)
        {
            NotifyError(HttpStatusCode.NotFound.ToString(), "کاربری با مشخصات وارد شده یافت نشد.");
            return Response();
        }

        return Response(await GenerateToken(user));
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