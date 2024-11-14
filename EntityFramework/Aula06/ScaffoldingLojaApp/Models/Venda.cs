using System;
using System.Collections.Generic;

namespace ScaffoldingLojaApp.Models;

public partial class Venda
{
    public int Id { get; set; }

    public int? ProdutoId { get; set; }

    public int Quantidade { get; set; }

    public DateTime DataVenda { get; set; }

    public virtual Produto? Produto { get; set; }
}
