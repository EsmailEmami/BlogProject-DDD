﻿using Blog.Application.Interfaces;
using Blog.Application.Services;
using Blog.Domain.CommandHandlers;
using Blog.Domain.Commands.Blog;
using Blog.Domain.Commands.User;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Events;
using Blog.Domain.Core.Notifications;
using Blog.Domain.EventHandlers;
using Blog.Domain.Events.Blog;
using Blog.Domain.Events.User;
using Blog.Domain.Interfaces;
using Blog.Infra.CrossCutting.Bus;
using Blog.Infra.CrossCutting.Identity.Interfaces;
using Blog.Infra.CrossCutting.Identity.Services;
using Blog.Infra.Data.EventSourcing;
using Blog.Infra.Data.Repository;
using Blog.Infra.Data.Repository.EventSourcing;
using Blog.Infra.Data.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infra.CrossCutting.IoC;

public static class NativeInjectorBootstrapper
{
    public static void RegisterServices(this IServiceCollection services)
    {
        // ASP.NET HttpContext dependency
        services.AddHttpContextAccessor();

        // Domain Bus (Mediator)
        services.AddScoped<IMediatorHandler, InMemoryBus>();

        // ASP.NET Authorization Polices
        //services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

        // Application
        services.AddScoped<IBlogAppService, BlogAppService>();
        services.AddScoped<IUserAppService, UserAppService>();

        // Domain - Events
        services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        // - Blog
        services.AddScoped<INotificationHandler<BlogRegisteredEvent>, BlogEventHandler>();
        services.AddScoped<INotificationHandler<BlogUpdatedEvent>, BlogEventHandler>();
        // - User
        services.AddScoped<INotificationHandler<UserRegisteredEvent>, UserEventHandler>();

        // Domain - Commands
        // - Blog
        services.AddScoped<IRequestHandler<RegisterNewBlogCommand, bool>, BlogCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateBlogCommand, bool>, BlogCommandHandler>();
        services.AddScoped<IRequestHandler<RemoveBlogCommand, bool>, BlogCommandHandler>();
        // - User
        services.AddScoped<IRequestHandler<RegisterNewUserCommand, bool>, UserCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateUserCommand, bool>, UserCommandHandler>();
        services.AddScoped<IRequestHandler<RemoveUserCommand, bool>, UserCommandHandler>();

        // Domain - 3rd parties
        //services.AddScoped<IHttpService, HttpService>();
        //services.AddScoped<IMailService, MailService>();

        // Infra - Data
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Infra - Data EventSourcing
        services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
        services.AddScoped<IEventStore, SqlEventStore>();

        // Infra - Identity Services
        //services.AddTransient<IEmailSender, AuthEmailMessageSender>();
        //services.AddTransient<ISmsSender, AuthSMSMessageSender>();

        // Infra - Identity
        services.AddScoped<IUser, AspNetUser>();
        services.AddSingleton<IJwtFactory, JwtFactory>();
    }
}