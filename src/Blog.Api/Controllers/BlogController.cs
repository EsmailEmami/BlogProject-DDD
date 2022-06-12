using Blog.Application.Interfaces;
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

    [HttpGet("blogs")]
    public async Task<IActionResult> Blogs()
    {
        List<BlogForShowViewModel> blogs = await _blogAppService.GetBlogs();
        return Response(blogs);
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
                bool result = await _blogTagAppService.AddBlogTagAsync(blogId, tag);
                if (!result)
                {
                    _blogAppService.DeleteBlog(blogId);
                    return Response();
                }
            }
        }

        if (IsValidOperation())
        {
            foreach (Guid category in blog.Categories)
            {
                bool result = await _blogCategoryAppService.AddBlogCategoryAsync(blogId, category);
                if (!result)
                {
                    _blogAppService.DeleteBlog(blogId);
                    return Response();
                }
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

        _blogAppService.UpdateBlog(blog);

        if (!IsValidOperation())
            return Response();

        // add relations
        if (IsValidOperation())
        {
            foreach (Guid tag in blog.Tags)
            {
                bool result = await _blogTagAppService.AddBlogTagAsync(blog.Id, tag);
                if (!result)
                {
                    _blogAppService.DeleteBlog(blog.Id);
                    return Response();
                }
            }
        }

        if (IsValidOperation())
        {
            foreach (Guid category in blog.Categories)
            {
                bool result = await _blogCategoryAppService.AddBlogCategoryAsync(blog.Id, category);
                if (!result)
                {
                    _blogAppService.DeleteBlog(blog.Id);
                    return Response();
                }
            }
        }

        return Response();
    }

    [HttpGet("detail")]
    public async Task<IActionResult> BlogDetail([FromQuery] Guid blogId)
    {
        return Response(await _blogAppService.GetBlogDetailAsync(blogId));
    }
}