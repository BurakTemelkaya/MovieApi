
using MediatR;
using MovieApi.Application.Features.MediatorDesignPatterns.Queries.TagQueries;
using MovieApi.Application.Features.MediatorDesignPatterns.Results.TagResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPatterns.Handlers.TagHandlers;

public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, GetTagByIdQueryResult>
{
    private readonly MovieContext _context;

    public GetTagByIdQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<GetTagByIdQueryResult> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Entities.Tag? tag = await _context.Tags.FindAsync(request.TagId);

        if (tag == null)
        {
            throw new Exception("Tag not found");
        }

        return new GetTagByIdQueryResult
        {
            TagId = tag.TagId,
            TagTitle = tag.TagTitle
        };
    }
}
