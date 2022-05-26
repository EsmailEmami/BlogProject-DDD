using System.Drawing;
using Blog.Application.Interfaces;
using Blog.Domain.Common.Constants;
using Blog.Domain.Common.Extensions;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.ViewModels.Blog;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Services.Api.Controllers;

public class BlogController : ApiController
{
    private readonly IBlogAppService _blogAppService;
    private readonly IBlogCategoryAppService _blogCategoryAppService;
    private readonly IBlogTagAppService _blogTagAppService;
    public BlogController(INotificationHandler<DomainNotification> notifications,
        IMediatorHandler mediator,
        IBlogAppService blogAppService,
        IBlogCategoryAppService blogCategoryAppService,
        IBlogTagAppService blogTagAppService) : base(notifications, mediator)
    {
        _blogAppService = blogAppService;
        _blogCategoryAppService = blogCategoryAppService;
        _blogTagAppService = blogTagAppService;
    }

    [HttpGet("author-blogs")]
    public async Task<IActionResult> AuthorBlogs([FromQuery] Guid authorId)
    {
        List<BlogForShowViewModel> blogs = await _blogAppService.GetAuthorBlogs(authorId);
        return Response(blogs);
    }


    [HttpPost("add-blog")]
    public async Task<IActionResult> AddBlog([FromBody] AddBlogViewModel blog)
    {
        if (!ModelState.IsValid)
        {
            NotifyModelStateErrors();
            return Response(blog);
        }

        Guid blogId = await _blogAppService.Register(blog);

        if (IsValidOperation())
        {
            foreach (Guid tag in blog.Tags)
            {
                _blogTagAppService.AddBlogTag(blogId, tag);
            }

            foreach (Guid category in blog.Categories)
            {
                _blogCategoryAppService.AddBlogCategory(blogId, category);
            }
        }

        return Response(blogId);
    }

    [HttpGet("get-blog-for-update")]
    public async Task<IActionResult> UpdateBlog([FromQuery] Guid blogId)
    {
        UpdateBlogViewModel? blog = await _blogAppService.GetBlogForUpdate(blogId);
        return Response(blog);
    }

    [HttpPut("update-blog")]
    public async Task<IActionResult> UpdateBlog([FromBody] UpdateBlogViewModel blog)
    {
        if (!ModelState.IsValid)
        {
            NotifyModelStateErrors();
            return Response(blog);
        }

        _blogAppService.Update(blog);

        if (!IsValidOperation())
            return Response();


        // remove all relations from blog
        List<Guid> blogTags = await _blogTagAppService.GetBlogTags(blog.Id);
        foreach (Guid blogTagId in blogTags)
        {
            _blogCategoryAppService.DeleteBlogCategory(blogTagId);
        }

        List<Guid> blogCategories = await _blogCategoryAppService.GetBlogCategories(blog.Id);
        foreach (Guid blogCategoryId in blogCategories)
        {
            _blogCategoryAppService.DeleteBlogCategory(blogCategoryId);
        }

        // add relations
        if (IsValidOperation())
        {
            foreach (Guid tag in blog.Tags)
            {
                _blogTagAppService.AddBlogTag(blog.Id, tag);
            }

            foreach (Guid category in blog.Categories)
            {
                _blogCategoryAppService.AddBlogCategory(blog.Id, category);
            }
        }


        return Response();
    }
}