﻿using AutoMapper;
using Blog.Domain.Commands.Blog;
using Blog.Domain.Commands.User;
using Blog.Domain.ViewModels.Blog;
using Blog.Domain.ViewModels.User;

namespace Blog.Application.AutoMapper;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<BlogViewModel, RegisterNewBlogCommand>()
            .ConstructUsing(c => new RegisterNewBlogCommand(c.AuthorId, c.BlogTitle, c.Summary, c.Description, c.ImageFile, c.ReadTime));
        CreateMap<BlogViewModel, UpdateBlogCommand>()
            .ConstructUsing(c => new UpdateBlogCommand(c.Id, c.AuthorId, c.BlogTitle, c.Summary, c.Description, c.ImageFile, c.ReadTime));
        CreateMap<RegisterViewModel, RegisterNewUserCommand>()
            .ConstructUsing(c => new RegisterNewUserCommand(c.FirstName, c.LastName, c.Email, c.Password, c.ConfirmPassword));
        CreateMap<UpdateUserViewModel, UpdateUserCommand>()
            .ConstructUsing(c => new UpdateUserCommand(c.Id, c.FirstName, c.LastName, c.Email));
    }
}