using AutoMapper;
using Blog.Domain.Commands.Blog;
using Blog.Domain.Commands.BlogCategory;
using Blog.Domain.Commands.Category;
using Blog.Domain.Commands.Comment;
using Blog.Domain.Commands.Role;
using Blog.Domain.Commands.Tag;
using Blog.Domain.Commands.User;
using Blog.Domain.Queries.User;
using Blog.Domain.ViewModels.Blog;
using Blog.Domain.ViewModels.Category;
using Blog.Domain.ViewModels.Comment;
using Blog.Domain.ViewModels.Role;
using Blog.Domain.ViewModels.Tag;
using Blog.Domain.ViewModels.User;

namespace Blog.Application.AutoMapper;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        // Commands 
        // Blog
        CreateMap<AddBlogViewModel, RegisterNewBlogCommand>()
            .ConstructUsing(c => new RegisterNewBlogCommand(c.AuthorId, c.BlogTitle, c.Summary, c.Description, c.ImageFile, c.ReadTime));
        CreateMap<UpdateBlogViewModel, UpdateBlogCommand>()
            .ConstructUsing(c => new UpdateBlogCommand(c.Id, c.AuthorId, c.BlogTitle, c.Summary, c.Description, c.ImageFile, c.ReadTime));
        // User
        CreateMap<RegisterViewModel, RegisterNewUserCommand>()
            .ConstructUsing(c => new RegisterNewUserCommand(c.FirstName, c.LastName, c.Email, c.Password, c.ConfirmPassword));
        CreateMap<UpdateUserViewModel, UpdateUserCommand>()
            .ConstructUsing(c => new UpdateUserCommand(c.Id, c.FirstName, c.LastName, c.Email));
        CreateMap<UpdateUserPasswordViewModel, UpdateUserPasswordCommand>()
            .ConstructUsing(c => new UpdateUserPasswordCommand(c.UserId, c.CurrentPassword, c.NewPassword, c.ConfirmNewPassword));
        // Category
        CreateMap<AddCategoryViewModel, RegisterNewCategoryCommand>()
            .ConstructUsing(c => new RegisterNewCategoryCommand(c.CategoryTitle));
        CreateMap<UpdateCategoryViewModel, UpdateCategoryCommand>()
            .ConstructUsing(c => new UpdateCategoryCommand(c.CategoryId, c.CategoryTitle));
        // Tag
        CreateMap<AddTagViewModel, RegisterNewTagCommand>()
            .ConstructUsing(c => new RegisterNewTagCommand(c.TagName));
        CreateMap<UpdateTagViewModel, UpdateTagCommand>()
            .ConstructUsing(c => new UpdateTagCommand(c.TagId, c.TagName));
        // Comment
        CreateMap<AddCommentViewModel, RegisterNewCommentCommand>()
            .ConstructUsing(c => new RegisterNewCommentCommand(c.UserId, c.BlogId, c.Title, c.CommentMessage));
        // Role
        CreateMap<UpdateRoleViewModel, UpdateRoleCommand>()
            .ConstructUsing(c => new UpdateRoleCommand(c.RoleId, c.RoleName));

        // Query
        // User
        CreateMap<LoginViewModel, IsUserExistsQuery>()
            .ConstructUsing(c => new IsUserExistsQuery(c.Email, c.Password));
    }
}