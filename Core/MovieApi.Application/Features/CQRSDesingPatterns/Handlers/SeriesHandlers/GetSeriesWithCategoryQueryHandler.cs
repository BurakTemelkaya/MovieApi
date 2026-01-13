using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesingPatterns.Result.CategoryResults;
using MovieApi.Application.Features.CQRSDesingPatterns.Result.SeriesResults;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesingPatterns.Handlers.SeriesHandlers;

public class GetSeriesWithCategoryQueryHandler
{
    private readonly MovieContext _context;

    public GetSeriesWithCategoryQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<List<GetSeriesWithCategoryQueryResult>> Handle(CancellationToken cancellationToken)
    {
        List<Series> values = await _context.Serieses.Include(s => s.Category).ToListAsync(cancellationToken);

        return [.. values.Select(s => new GetSeriesWithCategoryQueryResult
        {
            SeriesId = s.SeriesId,
            Title = s.Title,
            CoverImageUrl = s.CoverImageUrl,
            Rating = s.Rating,
            Description = s.Description,
            FirstAirDate = s.FirstAirDate,
            CreatedYear = s.CreatedYear,
            AvarageEpisodeDuration = s.AvarageEpisodeDuration,
            SeasonCount = s.SeasonCount,
            EpisodeCount = s.EpisodeCount,
            Status = s.Status,
            Category = new GetCategoryByIdResult
            {
                CategoryId = s.Category.CategoryId,
                CategoryName = s.Category.CategoryName
            }
        })];
    }
}