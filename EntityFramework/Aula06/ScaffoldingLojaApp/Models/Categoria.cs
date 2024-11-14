﻿using System;
using System.Collections.Generic;

namespace ScaffoldingLojaApp.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
