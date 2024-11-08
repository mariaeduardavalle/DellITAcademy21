using Microsoft.EntityFrameworkCore; 
public class BlogContext : DbContext 
{ 
    public DbSet<Blog> Blogs { get; set; } 
    public DbSet<Post> Posts { get; set; } 
    public DbSet<Tag> Tags { get; set; } 
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    { 
        base.OnConfiguring(optionsBuilder); 
        optionsBuilder.UseSqlServer("Server=localhost;Database=MeuProjeto;User Id=sa;Password=Me!14102004;TrustServerCertificate=True;Trusted_Connection=True;"); 
        //optionsBuilder.EnableSensitiveDataLogging().LogTo(Console.WriteLine); 
    } 
 
} 
 