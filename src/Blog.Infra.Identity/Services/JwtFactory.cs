using Blog.Infra.CrossCutting.Identity.Authorization;
using Blog.Infra.CrossCutting.Identity.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Blog.Infra.CrossCutting.Identity.Services;

public class JwtFactory : IJwtFactory
{
    private readonly JwtIssuerOptions _jwtOptions;

    public JwtFactory(IOptions<JwtIssuerOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
        ThrowIfInvalidOptions(_jwtOptions);
    }

    public async Task<string> GenerateJwtToken(ClaimsIdentity claimsIdentity)
    {
        claimsIdentity.AddClaims(new Claim[]
        {
            //new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
            new(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
        });

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = _jwtOptions.Issuer,
            Audience = _jwtOptions.Audience,
            Subject = claimsIdentity,
            NotBefore = _jwtOptions.NotBefore,
            Expires = _jwtOptions.Expiration,
            SigningCredentials = _jwtOptions.SigningCredentials,
        });

        return tokenHandler.WriteToken(token);
    }

    private static void ThrowIfInvalidOptions(JwtIssuerOptions options)
    {
        if (options == null) throw new ArgumentNullException(nameof(options));

        if (options.ValidFor <= TimeSpan.Zero)
        {
            throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));
        }

        if (options.SigningCredentials == null)
        {
            throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
        }

        if (options.JtiGenerator == null)
        {
            throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
        }
    }

    /// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
    private static long ToUnixEpochDate(DateTime date)
        => (long)Math.Round((date.ToUniversalTime() -
                             new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
            .TotalSeconds);
}