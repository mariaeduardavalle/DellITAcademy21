public class Produto 
{ 
    public int Id { get; set; } 
    public string Nome { get; set; } 
    public decimal Preco { get; set; } 
    public DateTime DataAdicionado { get; set; } 
 
    public int CategoriaId { get; set; } 
    public Categoria Categoria { get; set; } 
 
    public List<Venda> Vendas { get; set; } = new List<Venda>(); 
} 