using MediatR;
using MovieApi.Application.Features.MediatorDesignPatterns.Commands.TagCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPatterns.Handlers.TagHandlers;

public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand>
{
    private readonly MovieContext _context;

    public CreateTagCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        await _context.Tags.AddAsync(new() { TagTitle = request.Title }, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}