
using MeuProjeto.Models; 
using System.Data.SqlClient; 
using Microsoft.Data.SqlClient; 
using System; 
 
class Program 
{ 
    static void Main(string[] args) 
    { 
        Console.WriteLine("Iniciando conexão com BD..."); 
        using(var contexto = new ProdutoContext()) 
        { 
            /*Console.WriteLine("Inserindo dados"); 
            contexto.Produto.Add(new Produto{ Id = 500, Nome = "Prego" }); 
            contexto.Produto.Add(new Produto{ Id = 600, Nome = "Parafuso"}); 
            contexto.SaveChanges(); */

            var produto = contexto.Produto.FirstOrDefault(t => t.Id == 600);
            if(produto != null){
                produto.Nome = "Prego fino";
                contexto.SaveChanges();
            }

            var produtoParaRemover = contexto.Produto.Find(500);
            if(produtoParaRemover != null){
                contexto.Produto.Remove(produtoParaRemover);
                contexto.SaveChanges();
            }
        } 
    } 
} 