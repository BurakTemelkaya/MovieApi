using MediatR;
using MovieApi.Application.Features.MediatorDesignPatterns.Commands.TagCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPatterns.Handlers.TagHandlers;

public class RemoveTagCommandHandler : IRequestHandler<RemoveTagCommand>
{
    private readonly MovieContext _context;

    public RemoveTagCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveTagCommand request, CancellationToken cancellationToken)
    {
        var tag = await _context.Tags.FindAsync(request.TagId, cancellationToken);

        if (tag is null)
        {
            throw new Exception("Tag not found");
        }

        _context.Tags.Remove(tag);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
