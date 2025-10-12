using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesingPatterns.Result.CategoryResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesingPatterns.Handlers.CategoryHandlers;

public class GetCategoryQueryHandler
{
    private readonly MovieContext _context;

    public GetCategoryQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<List<GetCategoryQueryResult>> Handle(CancellationToken cancellationToken)
    {
        List<Domain.Entities.Category> categories = await _context.Categories.ToListAsync(cancellationToken);
        return categories.Select(x=> new GetCategoryQueryResult()
        {
            CategoryId = x.CategoryId,
            CategoryName = x.CategoryName
        }).ToList();
    }
}