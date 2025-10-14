using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPatterns.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPatterns.Results.CastResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPatterns.Handlers.CastHandlers;

public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResult>>
{
    private readonly MovieContext _context;

    public GetCastQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Entities.Cast> casts = await _context.Casts.AsNoTracking().ToListAsync(cancellationToken);

        List<GetCastQueryResult> result = casts.Select(c => new GetCastQueryResult
        {
            CastId = c.CastId,
            Name = c.Name,
            Surname = c.Surname,
            CastTitle = c.CastTitle,
            ImageUrl = c.ImageUrl,
            Overview = c.Overview,
            Biography = c.Biography
        }).ToList();

        return result;
    }
}
