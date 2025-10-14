using MediatR;
using MovieApi.Application.Features.MediatorDesignPatterns.Commands.CastCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPatterns.Handlers.CastHandlers;

public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand>
{
    private readonly MovieContext _context;

    public UpdateCastCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.Cast? cast = await _context.Casts.FindAsync(request.CastId, cancellationToken);

        if (cast == null)
        {
            throw new Exception("Cast bulunamadı");
        }

        cast.Overview= request.Overview;
        cast.Biography= request.Biography;
        cast.CastTitle= request.CastTitle;
        cast.Name= request.Name;
        cast.Surname= request.Surname;
        cast.ImageUrl= request.ImageUrl;
        cast.CastTitle= request.CastTitle;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
