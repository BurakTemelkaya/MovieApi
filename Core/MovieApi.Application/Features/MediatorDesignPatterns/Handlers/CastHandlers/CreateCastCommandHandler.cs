using MediatR;
using MovieApi.Application.Features.MediatorDesignPatterns.Commands.CastCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPatterns.Handlers.CastHandlers;

public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
{
    private readonly MovieContext _context;

    public CreateCastCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
    {
        await _context.Casts.AddAsync(new()
        {
            CastTitle = request.CastTitle,
            Name = request.Name,
            Surname = request.Surname,
            ImageUrl = request.ImageUrl,
            Overview = request.Overview,
            Biography = request.Biography
        }, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }
}