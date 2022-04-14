using Blog.Infra.CrossCutting.Identity.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Blog.Services.Api.SetupExtensions;

public static class AuthExtension
{
    public static IServiceCollection AddCustomizedAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var secretKey = configuration.GetValue<string>("SecretKey");
        var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
        var jwtAppSettingOptions = configuration.GetSection(nameof(JwtIssuerOptions));

        services.Configure<JwtIssuerOptions>(options =>
        {
            options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
            options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
            options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
        });

        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

            ValidateAudience = true,
            ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = signingKey,

            RequireExpirationTime = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(configureOptions =>
        {
            configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
            configureOptions.TokenValidationParameters = tokenValidationParameters;
            configureOptions.SaveToken = true;
        });

        services.AddAuthorization();

        return services;
    }

    public static IApplicationBuilder UseCustomizedAuth(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
        return app;
    }
}