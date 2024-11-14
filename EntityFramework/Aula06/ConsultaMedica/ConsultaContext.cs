using Microsoft.EntityFrameworkCore; 
 
public class ConsultaContext : DbContext 
{ 
    public DbSet<Medico> Medicos { get; set; } 
    public DbSet<Paciente> Pacientes { get; set; } 
    public DbSet<Consulta> Consultas { get; set; } 
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    { 
     optionsBuilder.UseSqlServer("Server=localhost;Database=ConsultaMedica;User Id=sa;Password=Me!14102004;TrustServerCertificate=True;Trusted_Connection=True;"); 
    } 
}