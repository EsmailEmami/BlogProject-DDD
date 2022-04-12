using Blog.Domain.CommandHandlers;
using Blog.Domain.Commands.Blog;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Events;
using Blog.Domain.Core.Notifications;
using Blog.Domain.EventHandlers;
using Blog.Domain.Events.Blog;
using Blog.Domain.Interfaces;
using Blog.Infra.CrossCutting.Bus;
using Blog.Infra.Data.Repository;
using Blog.Infra.Data.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infra.CrossCutting.IoC;

public static class NativeInjectorBootstrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        // ASP.NET HttpContext dependency
        services.AddHttpContextAccessor();

        // Domain Bus (Mediator)
        services.AddScoped<IMediatorHandler, InMemoryBus>();

        // ASP.NET Authorization Polices
        //services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

        // Application
        //services.AddScoped<ICustomerAppService, CustomerAppService>();

        // Domain - Events
        services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        services.AddScoped<INotificationHandler<BlogRegisteredEvent>, BlogEventHandler>();
        services.AddScoped<INotificationHandler<BlogUpdatedEvent>, BlogEventHandler>();

        // Domain - Commands
        services.AddScoped<IRequestHandler<RegisterNewBlogCommand, bool>, BlogCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateBlogCommand, bool>, BlogCommandHandler>();
        services.AddScoped<IRequestHandler<RemoveBlogCommand, bool>, BlogCommandHandler>();

        // Domain - 3rd parties
        //services.AddScoped<IHttpService, HttpService>();
        //services.AddScoped<IMailService, MailService>();

        // Infra - Data
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Infra - Data EventSourcing
        //services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
        //services.AddScoped<IEventStore, SqlEventStore>();

        // Infra - Identity Services
        //services.AddTransient<IEmailSender, AuthEmailMessageSender>();
        //services.AddTransient<ISmsSender, AuthSMSMessageSender>();

        // Infra - Identity
        //services.AddScoped<IUser, AspNetUser>();
        //services.AddSingleton<IJwtFactory, JwtFactory>();
    }
}