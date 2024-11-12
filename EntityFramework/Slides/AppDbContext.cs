using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Your_Connection_String");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Mapeamento de Produto
        modelBuilder.Entity<Produto>()
            .ToTable("Produtos")
            .HasKey(p => p.Id);

        modelBuilder.Entity<Produto>()
            .Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(100);

        // Mapeamento de Categoria
        modelBuilder.Entity<Categoria>()
            .ToTable("Categorias")
            .HasKey(c => c.Id);

        // Relacionamento 1:N entre Produto e Categoria
        modelBuilder.Entity<Produto>()
            .HasOne(p => p.Categoria)
            .WithMany(c => c.Produtos)
            .HasForeignKey(p => p.CategoriaId);
    }
}
