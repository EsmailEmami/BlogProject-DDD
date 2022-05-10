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
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
    public IActionResult GetCategoryForUpdate([FromQuery] Guid categoryId)
    {
        if (categoryId.IsEmpty())
        {
            NotifyError(HttpStatusCode.NotFound.ToString(),'لطفا آدرس را درست وارزدکنیذ');
            return Response();
        }

        UpdateCategoryViewModel category = _categoryAppService.GetCategoryForUpdate(categoryId);
        if (category == null)
        {
            NotifyError(HttpStatusCode.BadRequest.ToString(),'دسته بندی یافت نشد');
            return Response();
        }

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
}
