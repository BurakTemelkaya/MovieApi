namespace MovieApi.Application.Features.CQRSDesingPatterns.Queries.CategoryQueries;

public class GetCategoryByIdQuery
{
    public GetCategoryByIdQuery(int categoryId)
    {
        CategoryId = categoryId;
    }

    public int CategoryId { get; set; }
}