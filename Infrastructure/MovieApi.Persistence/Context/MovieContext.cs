using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Identity;
using System.Reflection;

namespace MovieApi.Persistence.Context;

public class MovieContext : IdentityDbContext<AppUser>
{

    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Movie> Movies { get; set; }
    public virtual DbSet<Review> Reviews { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }
    public virtual DbSet<Cast> Casts { get; set; }
    public virtual DbSet<Series> Serieses { get; set; }
}
