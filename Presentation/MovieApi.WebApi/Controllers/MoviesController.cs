using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesingPatterns.Commands.MovieCommands;
using MovieApi.Application.Features.CQRSDesingPatterns.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesingPatterns.Queries.MovieQueries;

namespace MovieApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
    private readonly GetMovieQueryHandler _getMovieQueryHandler;
    private readonly CreateMovieCommandHandler _createMovieCommandHandler;
    private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
    private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;

    public MoviesController(GetMovieByIdQueryHandler getMovieByIdQueryHandler, GetMovieQueryHandler getMovieQueryHandler, CreateMovieCommandHandler createMovieCommandHandler, UpdateMovieCommandHandler updateMovieCommandHandler, RemoveMovieCommandHandler removeMovieCommandHandler)
    {
        _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
        _getMovieQueryHandler = getMovieQueryHandler;
        _createMovieCommandHandler = createMovieCommandHandler;
        _updateMovieCommandHandler = updateMovieCommandHandler;
        _removeMovieCommandHandler = removeMovieCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
    {
        var movies = await _getMovieQueryHandler.Handle(cancellationToken);
        return Ok(movies);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovie(int id, CancellationToken cancellationToken = default)
    {
        var movie = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id), cancellationToken);
        return Ok(movie);
    }

    [HttpPost]
    public async Task<IActionResult> PostMovie([FromBody] CreateMovieCommand command, CancellationToken cancellationToken = default)
    {
        await _createMovieCommandHandler.Handle(command, cancellationToken);
        return Created("Film ekleme islemi basarili.", null);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateMovieCommand command, CancellationToken cancellationToken = default)
    {
        await _updateMovieCommandHandler.Handle(command, cancellationToken);
        return Ok("Film guncelleme islemi basarili.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteMovie(int id, CancellationToken cancellationToken = default)
    {
        await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(id), cancellationToken);
        return NoContent();
    }
}
