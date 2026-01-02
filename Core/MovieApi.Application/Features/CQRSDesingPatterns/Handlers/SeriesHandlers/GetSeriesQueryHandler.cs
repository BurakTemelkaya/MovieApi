using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesingPatterns.Result.SeriesResults;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesingPatterns.Handlers.SeriesHandlers;

public class GetSeriesQueryHandler
{
    private readonly MovieContext _context;

    public GetSeriesQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<List<GetSeriesQueryResult>> Handle(CancellationToken cancellationToken)
    {
        List<Series> values = await _context.Serieses.ToListAsync(cancellationToken);

        return [.. values.Select(s => new GetSeriesQueryResult
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
            CategoryId = s.CategoryId
        })];
    }
}
