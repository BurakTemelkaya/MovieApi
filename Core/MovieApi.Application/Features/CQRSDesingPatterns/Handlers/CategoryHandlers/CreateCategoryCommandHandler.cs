using MovieApi.Application.Features.CQRSDesingPatterns.Commands.CategoryCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesingPatterns.Handlers.CategoryHandlers;

public class CreateCategoryCommandHandler
{
    private readonly MovieContext _context;

    public CreateCategoryCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var newCategory = new Domain.Entities.Category
        {
            CategoryName = command.CategoryName
        };

        await _context.Categories.AddAsync(newCategory, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}