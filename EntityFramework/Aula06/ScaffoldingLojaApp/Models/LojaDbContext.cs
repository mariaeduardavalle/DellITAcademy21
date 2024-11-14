using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ScaffoldingLojaApp.Models;

public partial class LojaDbContext : DbContext
{

    public virtual DbSet<Categoria> Categorias { get; set; } = null!;

    public virtual DbSet<Produto> Produtos { get; set; } = null!;

    public virtual DbSet<Venda> Vendas { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=localhost;Database=LojaBD;User Id=sa;Password=Me!14102004;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC075E8830DC");

            entity.Property(e => e.Nome).HasMaxLength(100);
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Produtos__3214EC079692F637");

            entity.Property(e => e.DataAdicionado).HasColumnType("datetime");
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Preco).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK_Produto_Categoria");
        });

        modelBuilder.Entity<Venda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vendas__3214EC0793F6A814");

            entity.Property(e => e.DataVenda).HasColumnType("datetime");

            entity.HasOne(d => d.Produto).WithMany(p => p.Venda)
                .HasForeignKey(d => d.ProdutoId)
                .HasConstraintName("FK_Venda_Produto");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
