using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPatterns.Commands.TagCommands;
using MovieApi.Application.Features.MediatorDesignPatterns.Queries.TagQueries;
using MovieApi.Application.Features.MediatorDesignPatterns.Results.TagResults;

namespace MovieApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagsController : ControllerBase
{
    private readonly IMediator _mediator;
    public TagsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> TagList()
    {
        List<GetTagQueryResult> response = await _mediator.Send(new GetTagQuery());

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTag([FromBody] CreateTagCommand command)
    {
        await _mediator.Send(command);
        return Ok("Ekleme işlemi başarılı.");
    }

    [HttpGet("GetTagById")]
    public async Task<IActionResult> GetTag(int id)
    {
        GetTagByIdQueryResult response = await _mediator.Send(new GetTagByIdQuery(id));
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTag(int id)
    {
        await _mediator.Send(new RemoveTagCommand(id));
        return Ok("Silme işlemi başarılı.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTag([FromBody] UpdateTagCommand command)
    {
        await _mediator.Send(command);
        return Ok("Güncelleme işlemi başarılı.");
    }
}
