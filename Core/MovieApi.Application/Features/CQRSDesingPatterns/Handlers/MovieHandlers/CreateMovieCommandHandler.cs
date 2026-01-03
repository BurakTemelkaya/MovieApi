using MovieApi.Application.Features.CQRSDesingPatterns.Commands.MovieCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesingPatterns.Handlers.MovieHandlers;

public class CreateMovieCommandHandler
{
    private readonly MovieContext _context;

    public CreateMovieCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateMovieCommand command, CancellationToken cancellationToken)
    {
        Domain.Entities.Movie newMovie = new()
        {
            Title = command.Title,
            CoverImageUrl = command.CoverImageUrl,
            CreatedYear = command.CreatedYear,
            Description = command.Description,
            Duration = command.Duration,
            Rating = command.Rating,
            ReleaseDate = command.ReleaseDate,
            Status = command.Status,
            CategoryId = command.CategoryId
        };

        await _context.Movies.AddAsync(newMovie, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
