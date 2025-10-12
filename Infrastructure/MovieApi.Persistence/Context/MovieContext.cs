using Microsoft.EntityFrameworkCore;
using MovieApi.Domain.Entities;

namespace MovieApi.Persistence.Context;

public class MovieContext : DbContext
{

    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {

    }

    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Movie> Movies { get; set; }
    public virtual DbSet<Review> Reviews { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }
    public virtual DbSet<Cast> Casts { get; set; }
}
