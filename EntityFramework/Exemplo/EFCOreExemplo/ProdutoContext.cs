using Microsoft.EntityFrameworkCore;

public class ProdutoContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    { 
        base.OnConfiguring(optionsBuilder); 
        optionsBuilder.UseSqlServer("Server=localhost;Database=Exemplo;User Id=sa;Password=Me!14102004;TrustServerCertificate=True;Trusted_Connection=True;"); 
        //optionsBuilder.EnableSensitiveDataLogging().LogTo(Console.WriteLine); 
    } 
}
