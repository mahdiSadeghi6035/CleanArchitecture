using BlogManagement.Application.Common.Features;
using BlogManagement.Application.Dto.ArticleCategories;
using BlogManagement.Application.Features.ArticleCategories.Requests.Command;
using BlogManagement.Application.Features.ArticleCategories.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticleCategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public ArticleCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<ListArticleCategoryDto>>> GetAll()
    {
        var articleCategory = await _mediator.Send(new ListArticleCategoryRequestQuery());

        return Ok(articleCategory);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DetailsArticleCategoryDto>> Details(long id)
    {
        var command = new DetailsArticleCategoryRequestQuery();
        command.Id = id;
        var articleCategory = await _mediator.Send(command);

        return articleCategory is null ? NotFound() : Ok(articleCategory);
    }

    [HttpPost]
    public async Task<ActionResult<OperationResult>> Create(CreateArticleCategoryDto createArticleCategoryDto)
    {
        var command = new CreateArticleCategoryRequestCommand();
        command.CreateArticleCategoryDto = createArticleCategoryDto;

        var result = await _mediator.Send(command);
        return result.IsSucceeded ? Ok(result) : BadRequest(result);
    }


    [HttpPut]
    public async Task<ActionResult<OperationResult>> Edit(EditArticleCategoryDto editArticleCategoryDto)
    {
        var command = new EditArticleCategoryRequestCommand();
        command.EditArticleCategoryDto = editArticleCategoryDto;

        var result = await _mediator.Send(command);
        return result.IsSucceeded ? Ok(result) : BadRequest(result);
    }
}
