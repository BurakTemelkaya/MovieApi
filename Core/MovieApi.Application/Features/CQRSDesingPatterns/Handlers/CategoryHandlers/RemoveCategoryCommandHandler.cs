using MovieApi.Application.Features.CQRSDesingPatterns.Commands.CategoryCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesingPatterns.Handlers.CategoryHandlers;

public class RemoveCategoryCommandHandler
{
    private readonly MovieContext _context;

    public RemoveCategoryCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FindAsync(request.CategoryId, cancellationToken);

        if (category is null)
            throw new Exception("Category not found");

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
