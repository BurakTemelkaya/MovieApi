using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPatterns.Commands.TagCommands;

public class UpdateTagCommand : IRequest
{
    public int TagId { get; set; }
    public string TagTitle { get; set; }
}