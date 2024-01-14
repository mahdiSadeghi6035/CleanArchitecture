using BlogManagement.Application.Dto.Articles;
using BlogManagement.Application.Features.Articles.Requests.Commands;
using BlogManagement.Application.Features.Articles.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ArticleController : ControllerBase
{
    private readonly IMediator _mediator;

    public ArticleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<ListArticleDto>>> GetAll()
    {
        var article = await _mediator.Send(new ListArticleRequestQuery());
        return Ok(article);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<DetailsArticleDto>> Details(long id)
    {
        var command = new DetailsArticleRequestQuery() { Id = id };
        var article = await _mediator.Send(command);

        return article is null ? NotFound() : Ok(article);
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateArticleDto createArticleDto)
    {
        var command = new CreateArticleRequestCommand()
        {
            CreateArticleDto = createArticleDto
        };
        var result = await _mediator.Send(command);

        return result.IsSucceeded ? Ok(result.Message) : BadRequest(result.Message);
    }

    [HttpPut]
    public async Task<ActionResult> Edit(EditArticleDto editArticleDto)
    {
        var command = new EditArticleRequestCommand()
        {
            EditArticleDto = editArticleDto
        };

        var result = await _mediator.Send(command);

        return result.IsSucceeded ? Ok(result.Message) : BadRequest(result.Message);
    }

}
