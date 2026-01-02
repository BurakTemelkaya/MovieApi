using MovieApi.Application.Features.CQRSDesingPatterns.Commands.SeriesCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesingPatterns.Handlers.SeriesHandlers;

public class RemoveSeriesCommandHandler
{
    private readonly MovieContext _context;

    public RemoveSeriesCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(RemoveSeriesCommand removeSeriesCommand, CancellationToken cancellationToken)
    {
        Series? series = await _context.Serieses.FindAsync(removeSeriesCommand.SeriesId, cancellationToken);

        if (series == null)
            return false;

        _context.Serieses.Remove(series);

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
