namespace MovieApi.Application.Features.CQRSDesingPatterns.Commands.SeriesCommands;

public class RemoveSeriesCommand
{
    public int SeriesId { get; set; }

    public RemoveSeriesCommand(int seriesId)
    {
        SeriesId = seriesId;
    }
}
