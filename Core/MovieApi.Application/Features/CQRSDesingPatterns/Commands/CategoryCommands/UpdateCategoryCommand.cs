namespace MovieApi.Application.Features.CQRSDesingPatterns.Commands.CategoryCommands;

public class UpdateCategoryCommand
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}
