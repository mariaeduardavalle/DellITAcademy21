using System.Data.SqlClient; 
using Microsoft.Data.SqlClient; 
using System; 

class Program
{
    static void Main()
    {
        using var db = new ProdutoContext();
        db.Database.EnsureCreated();

        // 1. Criar um novo produto
        var novoProduto = new Produto { Nome = "Produto Teste3", Preco = 10.99M };
        db.Produtos.Add(novoProduto);
        db.SaveChanges();
        Console.WriteLine("Produto adicionado!");

        // 2. Ler produtos
        var produtos = db.Produtos.ToList();
        Console.WriteLine("Produtos no banco de dados:");
        foreach (var produto in produtos)
        {
            Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Preço: {produto.Preco}");
        }

        // 3. Atualizar um produto
        var produtoExistente = db.Produtos.First();
        produtoExistente.Preco = 19.99M;
        db.SaveChanges();
        Console.WriteLine("Produto atualizado!");

        // 4. Excluir um produto
        db.Produtos.Remove(produtoExistente);
        db.SaveChanges();
        Console.WriteLine("Produto excluído!");
    }
}

