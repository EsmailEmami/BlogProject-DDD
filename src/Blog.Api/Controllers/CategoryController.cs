using System.Net;
using Blog.Application.Interfaces;
using Blog.Domain.Common.Extensions;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.ViewModels.Category;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Services.Api.Controllers;

public class CategoryController : ApiController
{
    private readonly ICategoryAppService _categoryAppService;
    public CategoryController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator, ICategoryAppService categoryAppService) : base(notifications, mediator)
    {
        _categoryAppService = categoryAppService;
    }

    [HttpGet("categories")]
    [ProducesResponseType(typeof(List<CategoryForShowViewModel>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Categories()
    {
        List<CategoryForShowViewModel> categories = await _categoryAppService.GetAllCategoriesAsync();
        return Response(categories);
    }

    [HttpPost("add-category")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
    public IActionResult AddCategory([FromBody] AddCategoryViewModel category)
    {
        if (!ModelState.IsValid)
        {
            NotifyModelStateErrors();
            return Response();
        }

        _categoryAppService.AddCategoryAsync(category);
        return Response();
    }


    [HttpGet("get-category-for-update")]
    [ProducesResponseType(typeof(UpdateCategoryViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetCategoryForUpdate([FromQuery] Guid categoryId)
    {
        UpdateCategoryViewModel? category = await _categoryAppService.GetCategoryForUpdate(categoryId);
        return Response(category);
    }

    [HttpPut("update-category")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
    public IActionResult UpdateCategory([FromBody] UpdateCategoryViewModel category)
    {
        if (!ModelState.IsValid)
        {
            NotifyModelStateErrors();
            return Response();
        }

        _categoryAppService.UpdateCategory(category);
        return Response();
    }

    [HttpGet("blog-categories")]
    public async Task<IActionResult> BlogCategories([FromQuery] Guid blogId)
    {
        return Response(await _categoryAppService.GetBlogCategoriesAsync(blogId));
    }
}
