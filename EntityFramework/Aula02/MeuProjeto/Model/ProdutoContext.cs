using Microsoft.EntityFrameworkCore; 
 
namespace MeuProjeto.Models; 
 
public class ProdutoContext : DbContext 
{ 
    public DbSet<Produto> Produto { get; set; } 
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    { 
        base.OnConfiguring(optionsBuilder); 
        optionsBuilder.UseSqlServer("Server=localhost;Database=MeuProjeto;User Id=sa;Password=Me!14102004;TrustServerCertificate=True;Trusted_Connection=True;"); 
        //optionsBuilder.EnableSensitiveDataLogging().LogTo(Console.WriteLine); 
    } 
 
    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    { 
        base.OnModelCreating(modelBuilder); 
 
        // Mapeamento de Produto 
        modelBuilder.Entity<Produto>() 
            .ToTable("Produto") 
            .HasKey(p => p.Id); 
 
        modelBuilder.Entity<Produto>() 
            .Property(p => p.Nome) 
            .HasMaxLength(100); 
 
    } 
} 
 