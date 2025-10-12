using MovieApi.Application.Features.CQRSDesingPatterns.Commands.MovieCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesingPatterns.Handlers.MovieHandlers;

public class RemoveMovieCommandHandler
{
    private readonly MovieContext _context;

    public RemoveMovieCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveMovieCommand command, CancellationToken cancellationToken)
    {
        Domain.Entities.Movie? movie = await _context.Movies.FindAsync(command.MovieId);

        if (movie == null)
        {
            throw new Exception("Movie not found");
        }

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync(cancellationToken);

    }
}
