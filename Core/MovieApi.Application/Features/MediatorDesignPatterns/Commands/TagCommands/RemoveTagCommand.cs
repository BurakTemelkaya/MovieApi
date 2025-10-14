using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPatterns.Commands.TagCommands;

public class RemoveTagCommand:IRequest
{
    public RemoveTagCommand(int tagId)
    {
        TagId = tagId;
    }

    public int TagId { get; set; }
}