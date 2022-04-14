using System.Security.Claims;
using Blog.Infra.CrossCutting.Identity.Services;

namespace Blog.Infra.CrossCutting.Identity.Interfaces;

public interface IJwtFactory
{
    Task<JwtToken> GenerateJwtToken(ClaimsIdentity claimsIdentity);
}