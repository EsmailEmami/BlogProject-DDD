using Blog.Application.Interfaces;
using Blog.Application.Services;
using Blog.Domain.CommandHandlers;
using Blog.Domain.Commands.Blog;
using Blog.Domain.Commands.BlogCategory;
using Blog.Domain.Commands.Category;
using Blog.Domain.Commands.Comment;
using Blog.Domain.Commands.Tag;
using Blog.Domain.Commands.User;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.EventHandlers;
using Blog.Domain.Events.Blog;
using Blog.Domain.Events.User;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.Queries.Blog;
using Blog.Domain.Queries.Category;
using Blog.Domain.Queries.Comment;
using Blog.Domain.Queries.Tag;
using Blog.Domain.Queries.User;
using Blog.Domain.QueryHandlers;
using Blog.Domain.ViewModels.Blog;
using Blog.Domain.ViewModels.Category;
using Blog.Domain.ViewModels.Comment;
using Blog.Domain.ViewModels.User;
using Blog.Infra.CrossCutting.Bus;
using Blog.Infra.CrossCutting.Identity.Interfaces;
using Blog.Infra.CrossCutting.Identity.Services;
using Blog.Infra.Data.Repository;
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
        services.AddScoped<IAccountAppService, AccountAppService>();
        services.AddScoped<ICategoryAppService, CategoryAppService>();
        services.AddScoped<IBlogCategoryAppService, BlogCategoryAppService>();

        // Domain - Events
        services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        // - Blog
        services.AddScoped<INotificationHandler<BlogRegisteredEvent>, BlogEventHandler>();
        services.AddScoped<INotificationHandler<BlogUpdatedEvent>, BlogEventHandler>();
        services.AddScoped<INotificationHandler<BLogDeletedEvent>, BlogEventHandler>();
        // - User
        services.AddScoped<INotificationHandler<UserRegisteredEvent>, UserEventHandler>();

        // Domain - Commands
        // - Blog
        services.AddScoped<IRequestHandler<RegisterNewBlogCommand, Guid>, BlogCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateBlogCommand, bool>, BlogCommandHandler>();
        services.AddScoped<IRequestHandler<RemoveBlogCommand, bool>, BlogCommandHandler>();
        // - User
        services.AddScoped<IRequestHandler<RegisterNewUserCommand, Guid>, UserCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateUserCommand, bool>, UserCommandHandler>();
        services.AddScoped<IRequestHandler<RemoveUserCommand, bool>, UserCommandHandler>();
        // - Category 
        services.AddScoped<IRequestHandler<RegisterNewCategoryCommand, Guid>, CategoryCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateCategoryCommand, bool>, CategoryCommandHandler>();
        // - BlogCategory 
        services.AddScoped<IRequestHandler<RegisterNewBlogCategoryCommand, Guid>, BlogCategoryCommandHandler>();
        // - Comments 
        services.AddScoped<IRequestHandler<RegisterNewCommentCommand, Guid>, CommentCommandHandler>();
        // - Tag
        services.AddScoped<IRequestHandler<RegisterNewTagCommand, Guid>, TagCommandHandler>();

        // Domain - Queries
        // - Blog
        services.AddScoped<IRequestHandler<GetBlogForUpdateQuery, UpdateBlogViewModel>, BlogQueryHandler>();
        services.AddScoped<IRequestHandler<GetAuthorBlogsQuery, List<BlogForShowViewModel>>, BlogQueryHandler>();
        // - User
        services.AddScoped<IRequestHandler<GetUserByEmailQuery, User>, UserQueryHandler>();
        services.AddScoped<IRequestHandler<GetUserDashboardQuery, DashboardViewModel>, UserQueryHandler>();
        services.AddScoped<IRequestHandler<IsUserExistsQuery, bool>, UserQueryHandler>();
        // - Category
        services.AddScoped<IRequestHandler<GetCategoryForUpdateQuery, UpdateCategoryViewModel>, CategoryQueryHandler>();
        // - Comments 
        services.AddScoped<IRequestHandler<GetBlogCommentsQuery, List<CommentForShowViewModel>>, CommentQueryHandler>();
        // - Tag
        services.AddScoped<IRequestHandler<GetTagsQuery, List<Tag>>, TagQueryHandler>();

        // Infra - Data
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IBlogCategoryRepository, BlogCategoryRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Infra - Identity Services
        //services.AddTransient<IEmailSender, AuthEmailMessageSender>();
        //services.AddTransient<ISmsSender, AuthSMSMessageSender>();

        // Infra - Identity
        services.AddScoped<IUser, AspNetUser>();
        services.AddSingleton<IJwtFactory, JwtFactory>();
    }
}