namespace MovieApi.Application.Features.CQRSDesingPatterns.Commands.CategoryCommands;

public class RemoveCategoryCommand
{
    public RemoveCategoryCommand(int categoryId)
    {
        CategoryId = categoryId;
    }

    public int CategoryId { get; set; }
}
