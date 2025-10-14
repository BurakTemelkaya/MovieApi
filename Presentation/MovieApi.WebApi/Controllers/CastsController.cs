using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPatterns.Commands.CastCommands;
using MovieApi.Application.Features.MediatorDesignPatterns.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPatterns.Results.CastResults;

namespace MovieApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CastsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CastsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<CastsController>
    [HttpGet]
    public async Task<IActionResult> CastList(CancellationToken cancellationToken = default)
    {
        List<GetCastQueryResult> casts = await _mediator.Send(new GetCastQuery(), cancellationToken);
        return Ok(casts);
    }

    [HttpGet("GetCastById")]
    public async Task<IActionResult> GetCastById(int id, CancellationToken cancellationToken = default)
    {
        GetCastByIdQueryResult cast = await _mediator.Send(new GetCastByIdQuery(id), cancellationToken);
        return Ok(cast);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCast(CreateCastCommand command, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok("Ekleme işlemi başarılı.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCast(UpdateCastCommand command, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(command, cancellationToken);
        return Ok("Güncelleme işlemi başarılı.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCast(int id, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new RemoveCastCommand(id), cancellationToken);
        return Ok("Silme işlemi başarılı.");
    }
}
