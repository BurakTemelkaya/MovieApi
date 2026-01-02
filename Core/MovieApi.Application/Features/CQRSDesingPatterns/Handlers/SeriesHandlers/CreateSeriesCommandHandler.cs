using MovieApi.Application.Features.CQRSDesingPatterns.Commands.SeriesCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesingPatterns.Handlers.SeriesHandlers;

public class CreateSeriesCommandHandler
{
    private readonly MovieContext _context;

    public CreateSeriesCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateSeriesCommand command, CancellationToken cancellationToken)
    {
        Series series = new()
        {
            CoverImageUrl = command.CoverImageUrl,
            Rating = command.Rating,
            FirstAirDate = command.FirstAirDate,
            CreatedYear = command.CreatedYear,
            AvarageEpisodeDuration = command.AvarageEpisodeDuration,
            SeasonCount = command.SeasonCount,
            EpisodeCount = command.EpisodeCount,
            Status = command.Status,
            CategoryId = command.CategoryId,
            Title = command.Title,
            Description = command.Description,
        };

        await _context.Serieses.AddAsync(series, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}