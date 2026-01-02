using MovieApi.Application.Features.CQRSDesingPatterns.Commands.SeriesCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesingPatterns.Handlers.SeriesHandlers;

public class UpdateSeriesCommandHandler
{
    private readonly MovieContext _context;

    public UpdateSeriesCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handler(UpdateSeriesCommand updateSeriesCommand, CancellationToken cancellationToken)
    {
        Series? series = await _context.Serieses.FindAsync(updateSeriesCommand.SeriesId, cancellationToken);

        if (series == null)
        {
            throw new Exception("Series not found");
        }

        series.Title = updateSeriesCommand.Title;
        series.CoverImageUrl = updateSeriesCommand.CoverImageUrl;
        series.Rating = updateSeriesCommand.Rating;
        series.Description = updateSeriesCommand.Description;
        series.FirstAirDate = updateSeriesCommand.FirstAirDate;
        series.CreatedYear = updateSeriesCommand.CreatedYear;
        series.AvarageEpisodeDuration = updateSeriesCommand.AvarageEpisodeDuration;
        series.SeasonCount = updateSeriesCommand.SeasonCount;
        series.EpisodeCount = updateSeriesCommand.EpisodeCount;
        series.Status = updateSeriesCommand.Status;
        series.CategoryId = updateSeriesCommand.CategoryId;

        await _context.SaveChangesAsync(cancellationToken);

    }
}