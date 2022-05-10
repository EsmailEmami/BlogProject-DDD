using System.Net;
using Blog.Application.Interfaces;
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
}
