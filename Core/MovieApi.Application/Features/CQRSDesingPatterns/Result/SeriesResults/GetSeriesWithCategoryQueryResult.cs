using MovieApi.Application.Features.CQRSDesingPatterns.Result.CategoryResults;

namespace MovieApi.Application.Features.CQRSDesingPatterns.Result.SeriesResults;

public class GetSeriesWithCategoryQueryResult
{
    public int SeriesId { get; set; }
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }
    public decimal Rating { get; set; }
    public string Description { get; set; }
    public DateTime FirstAirDate { get; set; }
    public int CreatedYear { get; set; }
    public int? AvarageEpisodeDuration { get; set; }
    public int SeasonCount { get; set; }
    public int EpisodeCount { get; set; }
    public bool Status { get; set; }
    public GetCategoryByIdResult Category { get; set; }
}