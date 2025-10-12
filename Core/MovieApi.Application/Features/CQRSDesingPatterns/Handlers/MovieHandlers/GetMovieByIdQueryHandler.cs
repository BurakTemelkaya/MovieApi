using MovieApi.Application.Features.CQRSDesingPatterns.Queries.MovieQueries;
using MovieApi.Application.Features.CQRSDesingPatterns.Result.MovieResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesingPatterns.Handlers.MovieHandlers;

public class GetMovieByIdQueryHandler
{
    private readonly MovieContext _context;

    public GetMovieByIdQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<GetMovieQueryResult> Handle(GetMovieByIdQuery query, CancellationToken cancellationToken)
    {
        Domain.Entities.Movie? movie = await _context.Movies.FindAsync(query.MovieId, cancellationToken);

        return new GetMovieQueryResult()
        {
            MovieId = movie.MovieId,
            Description = movie.Description,
            ReleaseDate = movie.ReleaseDate,
            CoverImageUrl = movie.CoverImageUrl,
            CreatedYear = movie.CreatedYear,
            Duration = movie.Duration,
            Rating = movie.Rating,
            Title = movie.Title,
            Status = movie.Status            
        };
    }
}
