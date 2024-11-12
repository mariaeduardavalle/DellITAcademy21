public class Produto 
{ 
    public int Id { get; set; } 
    public string Nome { get; set; } = null!;
    public decimal Preco { get; set; } 
    public DateTime DataAdicionado { get; set; } 
 
    public int CategoriaId { get; set; } 
    public Categoria Categoria { get; set; } = null!;
 
    public List<Venda> Vendas { get; set; } = new List<Venda>(); 
} 