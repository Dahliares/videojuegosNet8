using Microsoft.EntityFrameworkCore;

namespace Videojuegos.Infrastructure;
public class VideojuegosDbContext : DbContext
{
    public VideojuegosDbContext(DbContextOptions<VideojuegosDbContext> options)
        : base(options) { }

    public DbSet<Videojuego> Videojuegos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Videojuego>(entity =>
        {
            entity.ToTable("videojuegos"); // nombre de la tabla real en MySQL

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre).HasColumnName("nombre");
            entity.Property(e => e.Genero).HasColumnName("tipo");
            entity.Property(e => e.Consola).HasColumnName("consola");
            entity.Property(e => e.Company).HasColumnName("compania");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Formato).HasColumnName("formato");
            entity.Property(e => e.Comentarios).HasColumnName("comentarios");
            entity.Property(e => e.Idioma).HasColumnName("idioma");
            entity.Property(e => e.Saga).HasColumnName("saga");
        });
    }
}
