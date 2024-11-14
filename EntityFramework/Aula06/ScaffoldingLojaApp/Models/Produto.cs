using System;
using System.Collections.Generic;

namespace ScaffoldingLojaApp.Models;

public partial class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public decimal Preco { get; set; }

    public DateTime DataAdicionado { get; set; }

    public int? CategoriaId { get; set; }

    public virtual Categoria? Categoria { get; set; }

    public virtual ICollection<Venda> Venda { get; set; } = new List<Venda>();
}
