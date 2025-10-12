using MovieApi.Application.Features.CQRSDesingPatterns.Commands.CategoryCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesingPatterns.Handlers.CategoryHandlers;

public class UpdateCategoryCommandHandler
{
    private readonly MovieContext _context;

    public UpdateCategoryCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        Domain.Entities.Category? category = await _context.Categories.FindAsync(command.CategoryId, cancellationToken);

        if (category is null)
            throw new Exception("Category not found");

        category.CategoryName = command.CategoryName;

        _context.Categories.Update(category);
        await _context.SaveChangesAsync(cancellationToken);
    }
}