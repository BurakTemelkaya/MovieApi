using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPatterns.Commands.TagCommands;

public class CreateTagCommand : IRequest
{
    public string Title { get; set; }
}