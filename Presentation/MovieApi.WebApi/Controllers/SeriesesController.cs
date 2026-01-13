using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesingPatterns.Commands.SeriesCommands;
using MovieApi.Application.Features.CQRSDesingPatterns.Handlers.SeriesHandlers;
using MovieApi.Application.Features.CQRSDesingPatterns.Queries.SeriesQueries;

namespace SeriesApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SeriesesController : ControllerBase
{
    private readonly GetSeriesByIdQueryHandler _getSeriesByIdQueryHandler;
    private readonly GetSeriesQueryHandler _getSeriesQueryHandler;
    private readonly CreateSeriesCommandHandler _createSeriesCommandHandler;
    private readonly UpdateSeriesCommandHandler _updateSeriesCommandHandler;
    private readonly RemoveSeriesCommandHandler _removeSeriesCommandHandler;
    private readonly GetSeriesWithCategoryQueryHandler _getSeriesWithCategoryQueryHandler;

    public SeriesesController(GetSeriesByIdQueryHandler getSeriesByIdQueryHandler, GetSeriesQueryHandler getSeriesQueryHandler, CreateSeriesCommandHandler createSeriesCommandHandler, UpdateSeriesCommandHandler updateSeriesCommandHandler, RemoveSeriesCommandHandler removeSeriesCommandHandler, GetSeriesWithCategoryQueryHandler getSeriesWithCategoryQueryHandler)
    {
        _getSeriesByIdQueryHandler = getSeriesByIdQueryHandler;
        _getSeriesQueryHandler = getSeriesQueryHandler;
        _createSeriesCommandHandler = createSeriesCommandHandler;
        _updateSeriesCommandHandler = updateSeriesCommandHandler;
        _removeSeriesCommandHandler = removeSeriesCommandHandler;
        _getSeriesWithCategoryQueryHandler = getSeriesWithCategoryQueryHandler;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var Seriess = await _getSeriesQueryHandler.Handle(cancellationToken);
        return Ok(Seriess);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSeries(int id, CancellationToken cancellationToken)
    {
        var Series = await _getSeriesByIdQueryHandler.Handle(new GetSeriesByIdQuery(id), cancellationToken);
        return Ok(Series);
    }

    [HttpPost]
    public async Task<IActionResult> PostSeries([FromBody] CreateSeriesCommand command, CancellationToken cancellationToken)
    {
        await _createSeriesCommandHandler.Handle(command, cancellationToken);
        return Created("Dizi ekleme islemi basarili.", null);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateSeriesCommand command, CancellationToken cancellationToken)
    {
        await _updateSeriesCommandHandler.Handle(command, cancellationToken);
        return Ok("Dizi guncelleme islemi basarili.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteSeries(int id, CancellationToken cancellationToken)
    {
        await _removeSeriesCommandHandler.Handle(new RemoveSeriesCommand(id), cancellationToken);
        return NoContent();
    }

    [HttpGet("GetSeriesWithCategory")]
    public async Task<IActionResult> GetSeriesWithCategory(CancellationToken cancellationToken)
    {
        var serieses = await _getSeriesWithCategoryQueryHandler.Handle(cancellationToken);
        return Ok(serieses);
    }
}
