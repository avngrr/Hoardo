using System.Text.Json;
using Domain.Entities;
using Domain.Entities.Movies;
using Domain.Entities.Tv;
using Microsoft.EntityFrameworkCore;

namespace Server.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Serie> Series { get; set; }
    public DbSet<Season> Seasons { get; set; }
    public DbSet<Episode> Episodes { get; set; }
    public DbSet<MediaFileInfo> Files { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Movie>(entity =>
        {
            entity.Property(movie => movie.Genres)
                .HasConversion(
                    s => JsonSerializer.Serialize(s, new JsonSerializerOptions()),
                    s => JsonSerializer.Deserialize<List<string>>(s, new JsonSerializerOptions()));
        });
        builder.Entity<Serie>(entity =>
        {
            entity.Property(serie => serie.Genres)
                .HasConversion(
                    s => JsonSerializer.Serialize(s, new JsonSerializerOptions()),
                    s => JsonSerializer.Deserialize<List<string>>(s, new JsonSerializerOptions()));
        });
    }
}
