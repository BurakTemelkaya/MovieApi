using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPatterns.Queries.TagQueries;
using MovieApi.Application.Features.MediatorDesignPatterns.Results.TagResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPatterns.Handlers.TagHandlers;

public class GetTagQueryHandler : IRequestHandler<GetTagQuery, List<GetTagQueryResult>>
{
    private readonly MovieContext _context;

    public GetTagQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<List<GetTagQueryResult>> Handle(GetTagQuery request, CancellationToken cancellationToken)
    {
        return await _context.Tags
            .Select(t => new GetTagQueryResult
            {
                TagId = t.TagId,
                TagTitle = t.TagTitle
            }).ToListAsync();
    }
}
