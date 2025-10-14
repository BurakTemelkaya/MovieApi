namespace MovieApi.Application.Features.CQRSDesingPatterns.Queries.MovieQueries;

public class GetMovieByIdQuery
{
    public GetMovieByIdQuery(int movieId)
    {
        MovieId = movieId;
    }

    public int MovieId { get; set; }
    
}
