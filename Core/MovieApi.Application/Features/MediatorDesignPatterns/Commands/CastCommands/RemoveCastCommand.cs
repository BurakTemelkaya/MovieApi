using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPatterns.Commands.CastCommands;

public class RemoveCastCommand:IRequest
{
    public RemoveCastCommand(int castId)
    {
        CastId = castId;
    }

    public int CastId { get; set; }
}