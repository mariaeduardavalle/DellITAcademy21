using System; 
 
public class Program 
{ 
    public static void Main() 
    { 
        using (var context = new LojaDbContext()) 
        { 
            var eletronicos = new Categoria { Nome = "Eletrônicos" }; 
            var roupas = new Categoria { Nome = "Roupas" }; 
            var alimentos = new Categoria { Nome = "Alimentos" }; 
 
            context.Categorias.AddRange(eletronicos, roupas, alimentos); 
 
            var smartphone = new Produto { Nome = "Smartphone", Preco = 1200.00m, DataAdicionado = DateTime.Now, Categoria = eletronicos }; 
            var laptop = new Produto { Nome = "Laptop", Preco = 3000.00m, DataAdicionado = DateTime.Now, Categoria = eletronicos }; 
            var camisa = new Produto { Nome = "Camisa", Preco = 80.00m, DataAdicionado = DateTime.Now, Categoria = roupas }; 
            var arroz = new Produto { Nome = "Arroz", Preco = 20.00m, DataAdicionado = DateTime.Now, Categoria = alimentos }; 
 
            context.Produtos.AddRange(smartphone, laptop, camisa, arroz); 
 
            var venda1 = new Venda { Produto = smartphone, Quantidade = 2, DataVenda = DateTime.Now }; 
            var venda2 = new Venda { Produto = laptop, Quantidade = 1, DataVenda = DateTime.Now }; 
            var venda3 = new Venda { Produto = camisa, Quantidade = 3, DataVenda = DateTime.Now }; 
 
            context.Vendas.AddRange(venda1, venda2, venda3); 
 
            context.SaveChanges(); 
        } 
 
        Console.WriteLine("Dados inseridos com sucesso!"); 
    } 
} 
 
