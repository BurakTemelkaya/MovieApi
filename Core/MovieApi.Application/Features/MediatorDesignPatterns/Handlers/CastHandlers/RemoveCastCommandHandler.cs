using MediatR;
using MovieApi.Application.Features.MediatorDesignPatterns.Commands.CastCommands;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.MediatorDesignPatterns.Handlers.CastHandlers;

public class RemoveCastCommandHandler : IRequestHandler<RemoveCastCommand>
{
    private readonly MovieContext _context;

    public RemoveCastCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Cast? cast = await _context.Casts.FindAsync(request.CastId);

        if (cast == null)
        {
            throw new Exception("Cast not found");
        }

        _context.Casts.Remove(cast);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
