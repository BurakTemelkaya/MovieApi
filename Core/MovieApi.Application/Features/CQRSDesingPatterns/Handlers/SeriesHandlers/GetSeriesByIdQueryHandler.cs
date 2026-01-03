using MovieApi.Application.Features.CQRSDesingPatterns.Queries.SeriesQueries;
using MovieApi.Application.Features.CQRSDesingPatterns.Result.SeriesResults;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesingPatterns.Handlers.SeriesHandlers;

public class GetSeriesByIdQueryHandler
{
    private readonly MovieContext _context;

    public GetSeriesByIdQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<GetSeriesByIdQueryResult?> Handle(GetSeriesByIdQuery query, CancellationToken cancellationToken)
    {
        Series? series = await _context.Serieses.FindAsync(query.SeriesId, cancellationToken);

        if (series == null)
            return null;

        return new GetSeriesByIdQueryResult
        {
            CoverImageUrl = series.CoverImageUrl,
            CreatedYear = series.CreatedYear,
            Description = series.Description,
            EpisodeCount = series.EpisodeCount,
            FirstAirDate = series.FirstAirDate,
            Rating = series.Rating,
            SeasonCount = series.SeasonCount,
            SeriesId = series.SeriesId,
            Status = series.Status,
            Title = series.Title,
            AvarageEpisodeDuration = series.AvarageEpisodeDuration,
            CategoryId = series.CategoryId
        };
    }
}
