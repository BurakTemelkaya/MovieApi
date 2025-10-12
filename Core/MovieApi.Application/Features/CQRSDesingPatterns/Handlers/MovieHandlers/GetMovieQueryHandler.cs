using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesingPatterns.Result.MovieResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesingPatterns.Handlers.MovieHandlers;

public class GetMovieQueryHandler
{
    private readonly MovieContext _context;
    public GetMovieQueryHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task<List<GetMovieQueryResult>> Handle(CancellationToken cancellationToken)
    {
        List<Domain.Entities.Movie> movies = await _context.Movies.ToListAsync(cancellationToken);
        return movies.Select(x => new GetMovieQueryResult()
        {
            MovieId = x.MovieId,
            Description = x.Description,
            ReleaseDate = x.ReleaseDate,
            CoverImageUrl = x.CoverImageUrl,
            CreatedYear = x.CreatedYear,
            Duration = x.Duration,
            Rating = x.Rating,
            Title = x.Title,
            Status = x.Status
        }).ToList();
    }
}
