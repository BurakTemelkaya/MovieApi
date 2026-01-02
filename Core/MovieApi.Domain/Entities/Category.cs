namespace MovieApi.Domain.Entities;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public bool Status { get; set; }
    public string? Description { get; set; }
    public ICollection<Movie> Movies { get; set; }

    public Category()
    {
        CategoryName = string.Empty;
        Movies = new HashSet<Movie>();
    }
}
