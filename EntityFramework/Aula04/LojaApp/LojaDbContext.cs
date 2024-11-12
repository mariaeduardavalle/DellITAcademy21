using Microsoft.EntityFrameworkCore; 
 
public class LojaDbContext : DbContext 
{ 
    public DbSet<Categoria> Categorias { get; set; } 
    public DbSet<Produto> Produtos { get; set; } 
    public DbSet<Venda> Vendas { get; set; } 
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    { 
     optionsBuilder.UseSqlServer("Server=localhost;Database=MeuProjetoVendas;User Id=sa;Password=Me!14102004;TrustServerCertificate=True;Trusted_Connection=True;"); 
    } 
}