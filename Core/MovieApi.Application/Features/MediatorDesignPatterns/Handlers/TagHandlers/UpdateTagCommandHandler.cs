using MediatR;
using MovieApi.Application.Features.MediatorDesignPatterns.Commands.TagCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPatterns.Handlers.TagHandlers;

public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand>
{
    private readonly MovieContext _context;

    public UpdateTagCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        var tag = await _context.Tags.FindAsync(request.TagId);

        if (tag == null)
        {
            throw new Exception("Tag not found");
        }

        tag.TagTitle = request.TagTitle;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
