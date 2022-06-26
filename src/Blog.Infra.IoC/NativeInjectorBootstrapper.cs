using Blog.Application.Interfaces;
using Blog.Application.Services;
using Blog.Domain.CommandHandlers;
using Blog.Domain.Commands.Blog;
using Blog.Domain.Commands.BlogCategory;
using Blog.Domain.Commands.BlogTag;
using Blog.Domain.Commands.Category;
using Blog.Domain.Commands.Comment;
using Blog.Domain.Commands.Role;
using Blog.Domain.Commands.Tag;
using Blog.Domain.Commands.User;
using Blog.Domain.Commands.UserRole;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.EventHandlers;
using Blog.Domain.Events.Blog;
using Blog.Domain.Events.User;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.Queries.Blog;
using Blog.Domain.Queries.BlogCategory;
using Blog.Domain.Queries.BlogTag;
using Blog.Domain.Queries.Category;
using Blog.Domain.Queries.Comment;
using Blog.Domain.Queries.Role;
using Blog.Domain.Queries.Tag;
using Blog.Domain.Queries.User;
using Blog.Domain.Queries.UserRole;
using Blog.Domain.QueryHandlers;
using Blog.Domain.ViewModels.Blog;
using Blog.Domain.ViewModels.Category;
using Blog.Domain.ViewModels.Comment;
using Blog.Domain.ViewModels.Tag;
using Blog.Domain.ViewModels.User;
using Blog.Infra.CrossCutting.Bus;
using Blog.Infra.CrossCutting.Identity.Interfaces;
using Blog.Infra.CrossCutting.Identity.Services;
using Blog.Infra.Data.Repository;
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
        services.AddScoped<ITagAppService, TagAppService>();
        services.AddScoped<IBlogTagAppService, BlogTagAppService>();
        services.AddScoped<IRoleAppService, RoleAppService>();
        services.AddScoped<IUserRoleAppService, UserRoleAppService>();
        services.AddScoped<ICommentAppService, CommentAppService>();

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
        services.AddScoped<IRequestHandler<RegisterNewUserCommand, UserForShowViewModel>, UserCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateUserCommand, bool>, UserCommandHandler>();
        services.AddScoped<IRequestHandler<RemoveUserCommand, bool>, UserCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateUserPasswordCommand, bool>, UserCommandHandler>();
        // - Category 
        services.AddScoped<IRequestHandler<RegisterNewCategoryCommand, CategoryForShowViewModel>, CategoryCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateCategoryCommand, bool>, CategoryCommandHandler>();
        // - BlogCategory 
        services.AddScoped<IRequestHandler<RegisterNewBlogCategoryCommand, bool>, BlogCategoryCommandHandler>();
        services.AddScoped<IRequestHandler<RemoveBlogCategoryCommand, bool>, BlogCategoryCommandHandler>();
        // - Comments 
        services.AddScoped<IRequestHandler<RegisterNewCommentCommand, CommentForShowViewModel>, CommentCommandHandler>();
        // - Tag
        services.AddScoped<IRequestHandler<RegisterNewTagCommand, TagForShowViewModel>, TagCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateTagCommand, bool>, TagCommandHandler>();
        services.AddScoped<IRequestHandler<RemoveTagCommand, bool>, TagCommandHandler>();
        // _ BlogTag
        services.AddScoped<IRequestHandler<RegisterNewBlogTagCommand, bool>, BlogTagCommandHandler>();
        services.AddScoped<IRequestHandler<RemoveBlogTagCommand, bool>, BlogTagCommandHandler>();
        // - Role
        services.AddScoped<IRequestHandler<RegisterNewRoleCommand, Guid>, RoleCommandHandler>();
        // - User Role 
        services.AddScoped<IRequestHandler<RegisterNewUserRoleCommand, bool>, UserRoleCommandHandler>();

        // Domain - Queries
        // - Blog
        services.AddScoped<IRequestHandler<GetBlogForUpdateQuery, UpdateBlogViewModel>, BlogQueryHandler>();
        services.AddScoped<IRequestHandler<GetAuthorBlogsQuery, List<BlogForShowViewModel>>, BlogQueryHandler>();
        services.AddScoped<IRequestHandler<GetBlogsQuery, List<BlogForShowViewModel>>, BlogQueryHandler>();
        services.AddScoped<IRequestHandler<GetBlogDetailQuery, BlogDetailViewModel>, BlogQueryHandler>();
        // - User
        services.AddScoped<IRequestHandler<GetUserByEmailQuery, User>, UserQueryHandler>();
        services.AddScoped<IRequestHandler<GetUserDashboardQuery, DashboardViewModel>, UserQueryHandler>();
        services.AddScoped<IRequestHandler<IsUserExistsQuery, bool>, UserQueryHandler>();
        services.AddScoped<IRequestHandler<GetUsersQuery, List<UserForShowViewModel>>, UserQueryHandler>();
        services.AddScoped<IRequestHandler<GetUsersCountQuery, int>, UserQueryHandler>();
        // - Category
        services.AddScoped<IRequestHandler<GetCategoryForUpdateQuery, UpdateCategoryViewModel>, CategoryQueryHandler>();
        services.AddScoped<IRequestHandler<GetAllCategoriesQuery, List<CategoryForShowViewModel>>, CategoryQueryHandler>();
        services.AddScoped<IRequestHandler<GetBlogCategoriesQuery, List<CategoryForShowViewModel>>, CategoryQueryHandler>();
        // - Blog Category
        services.AddScoped<IRequestHandler<GetBlogCategoriesIdByBlogQuery, List<Guid>>, BlogCategoryQueryHandler>();
        // - Comments 
        services.AddScoped<IRequestHandler<GetBlogCommentsQuery, List<CommentForShowViewModel>>, CommentQueryHandler>();
        // - Tag
        services.AddScoped<IRequestHandler<GetTagsQuery, List<TagForShowViewModel>>, TagQueryHandler>();
        services.AddScoped<IRequestHandler<GetTagForUpdateQuery, UpdateTagViewModel>, TagQueryHandler>();
        services.AddScoped<IRequestHandler<GetBlogTagsQuery, List<TagForShowViewModel>>, TagQueryHandler>();
        // - Blog Tag
        services.AddScoped<IRequestHandler<GetBlogTagsIdByBlogQuery, List<Guid>>, BlogTagQueryHandler>();
        // - Role
        services.AddScoped<IRequestHandler<GetAllRolesQuery, List<Role>>, RoleQueryHandler>();
        // - User Role
        services.AddScoped<IRequestHandler<GetAllUserRolesIdQuery, List<Guid>>, UserRoleQueryHandler>();

        // Infra - Data
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IBlogCategoryRepository, BlogCategoryRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<IBlogTagRepository, BlogTagRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();

        // Infra - Identity Services
        //services.AddTransient<IEmailSender, AuthEmailMessageSender>();
        //services.AddTransient<ISmsSender, AuthSMSMessageSender>();

        // Infra - Identity
        services.AddScoped<IUser, AspNetUser>();
        services.AddSingleton<IJwtFactory, JwtFactory>();
    }
}