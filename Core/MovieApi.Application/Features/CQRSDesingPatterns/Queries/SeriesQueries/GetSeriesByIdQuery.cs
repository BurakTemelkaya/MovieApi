namespace MovieApi.Application.Features.CQRSDesingPatterns.Queries.SeriesQueries;

public class GetSeriesByIdQuery
{
    public int SeriesId { get; set; }

    public GetSeriesByIdQuery(int seriesId)
    {
        SeriesId = seriesId;
    }
}