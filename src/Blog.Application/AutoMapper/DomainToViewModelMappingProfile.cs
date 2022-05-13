using AutoMapper;
using Blog.Domain.Models;
using Blog.Domain.ViewModels.Blog;
using Blog.Domain.ViewModels.User;

namespace Blog.Application.AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        CreateMap<Domain.Models.Blog, AddBlogViewModel>();
        CreateMap<User, RegisterViewModel>();
    }
}