public class Categoria 
{ 
    public int Id { get; set; } 
    public string Nome { get; set; } = null!;
    public List<Produto> Produtos { get; set; } = new List<Produto>(); 
} 