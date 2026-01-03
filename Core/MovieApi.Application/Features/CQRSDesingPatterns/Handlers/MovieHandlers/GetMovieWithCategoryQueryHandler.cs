using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesingPatterns.Result.MovieResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesingPatterns.Handlers.MovieHandlers;

public class GetMovieWithCategoryQueryHandler
{
    private readonly MovieContext _context;

    public GetMovieWithCategoryQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<List<GetMovieWithCategoryQueryResult>> Handle(CancellationToken cancellationToken)
    {
        var movies = await _context.Movies.Include(m => m.Category).ToListAsync(cancellationToken);


        return movies.Select(m => new GetMovieWithCategoryQueryResult
        {
            MovieId = m.MovieId,
            Title = m.Title,
            CoverImageUrl = m.CoverImageUrl,
            Rating = m.Rating,
            Description = m.Description,
            Duration = m.Duration,
            ReleaseDate = m.ReleaseDate,
            CreatedYear = m.CreatedYear,
            Status = m.Status,
            Category = new()
            {
                CategoryId = m.Category.CategoryId,
                CategoryName = m.Category.CategoryName,
            },
        }).ToList();

    }
}