using AutoMapper;
using Blog.Application.ViewModels.Blog;
using Blog.Application.ViewModels.User;
using Blog.Domain.Commands.Blog;
using Blog.Domain.Commands.User;

namespace Blog.Application.AutoMapper;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<BlogViewModel, RegisterNewBlogCommand>()
            .ConstructUsing(c => new RegisterNewBlogCommand(c.BlogTitle));
        CreateMap<BlogViewModel, UpdateBlogCommand>()
            .ConstructUsing(c => new UpdateBlogCommand(c.Id, c.BlogTitle));
        CreateMap<UserViewModel, RegisterNewUserCommand>()
            .ConstructUsing(c => new RegisterNewUserCommand(c.FirstName, c.LastName, c.Email));
        CreateMap<UserViewModel, UpdateUserCommand>()
            .ConstructUsing(c => new UpdateUserCommand(c.Id, c.FirstName, c.LastName, c.Email));
    }
}