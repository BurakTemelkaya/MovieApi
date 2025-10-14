namespace MovieApi.Application.Features.CQRSDesingPatterns.Commands.MovieCommands;

public class RemoveMovieCommand
{
    public RemoveMovieCommand(int movieId)
    {
        MovieId = movieId;
    }

    public int MovieId { get; set; }
}