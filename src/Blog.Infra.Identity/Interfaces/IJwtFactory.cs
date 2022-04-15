using System.Security.Claims;
using Blog.Infra.CrossCutting.Identity.Services;

namespace Blog.Infra.CrossCutting.Identity.Interfaces;

public interface IJwtFactory
{
    Task<string> GenerateJwtToken(ClaimsIdentity claimsIdentity);
}