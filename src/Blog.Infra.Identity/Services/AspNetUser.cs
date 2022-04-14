using Blog.Domain.Common.Extensions;
using Blog.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Blog.Infra.CrossCutting.Identity.Services;

public class AspNetUser : IUser
{
    private readonly IHttpContextAccessor _accessor;

    public AspNetUser(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public Guid UserId =>
        _accessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier).ToGuid();

    public bool IsAuthenticated() => _accessor.HttpContext!.User.Identity!.IsAuthenticated;
}