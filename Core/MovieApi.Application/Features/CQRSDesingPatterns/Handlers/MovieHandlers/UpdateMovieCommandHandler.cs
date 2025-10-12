using MovieApi.Application.Features.CQRSDesingPatterns.Commands.MovieCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesingPatterns.Handlers.MovieHandlers;

public class UpdateMovieCommandHandler
{
    private readonly MovieContext _context;

    public UpdateMovieCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateMovieCommand command, CancellationToken cancellationToken)
    {
        Domain.Entities.Movie? movie = await _context.Movies.FindAsync(command.MovieId, cancellationToken);
        if (movie == null)
        {
            throw new Exception("Movie not found");
        }

        movie.Title = command.Title;
        movie.Rating = command.Rating;
        movie.Status = command.Status;
        movie.CoverImageUrl = command.CoverImageUrl;
        movie.CreatedYear = command.CreatedYear;
        movie.Description = command.Description;
        movie.ReleaseDate = command.ReleaseDate;
        movie.Duration = command.Duration;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
