using MediatR;
using MovieApi.Application.Features.MediatorDesignPatterns.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPatterns.Results.CastResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPatterns.Handlers.CastHandlers;

public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
{
    private readonly MovieContext _context;

    public GetCastByIdQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Entities.Cast? cast = await _context.Casts.FindAsync(request.CastId, cancellationToken);

        if (cast == null)
        {
            throw new Exception($"Cast with ID {request.CastId} not found.");
        }

        GetCastByIdQueryResult result = new GetCastByIdQueryResult
        {
            CastId = cast.CastId,
            Name = cast.Name,
            Surname = cast.Surname,
            CastTitle = cast.CastTitle,
            ImageUrl = cast.ImageUrl,
            Overview = cast.Overview,
            Biography = cast.Biography
        };

        return result;
    }
}
