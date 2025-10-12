using MovieApi.Application.Features.CQRSDesingPatterns.Queries.CategoryQueries;
using MovieApi.Application.Features.CQRSDesingPatterns.Result.CategoryResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesingPatterns.Handlers.CategoryHandlers;

public class GetCategoryByIdQueryHandler
{
    private readonly MovieContext _context;

    public GetCategoryByIdQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<GetCategoryQueryResult> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
    {
        Domain.Entities.Category? value = await _context.Categories.FindAsync(query.CategoryId, cancellationToken);

        return new GetCategoryQueryResult()
        {
            CategoryId = value.CategoryId,
            CategoryName = value.CategoryName,
        };
    }
}