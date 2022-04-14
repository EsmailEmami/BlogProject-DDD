using AutoMapper;
using Blog.Application.ViewModels.Blog;
using Blog.Application.ViewModels.User;
using Blog.Domain.Models;

namespace Blog.Application.AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        CreateMap<Domain.Models.Blog, BlogViewModel>();
        CreateMap<User, UserViewModel>();
    }
}