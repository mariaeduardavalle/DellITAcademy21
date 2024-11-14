using System;
namespace ScaffoldingLojaApp.Models;

public class Program
{
    public static void Main(){

        using (var context = new LojaDbContext()){

             Console.WriteLine("\n 1) \n");

            var produtos = context.Produtos.ToList();
            foreach (var produto0 in produtos)
            {
                Console.WriteLine($"{produto0.Nome}");
            }

             Console.WriteLine("-------------------------------------");

           var produto = (from p in context.Produtos
                            select p).ToList();
            foreach(var produtos1 in produtos){
                Console.WriteLine($"\n{produtos1.Nome} - R${produtos1.Preco}");
            }

            // 2) Média de preço dos produtos por categoria
            Console.WriteLine("\n 2) \n");
            var mediaPorCategoria = from p in context.Produtos
                                    group p by p.Categoria.Nome into grupo
                                    select new{
                                        Categoria = grupo.Key,
                                        MediaPreco = grupo.Average(p => p.Preco)
                                    };
            
            foreach(var media in mediaPorCategoria){
                Console.WriteLine($"Categoria: {media.Categoria}\n Média: R$ {media.MediaPreco}");
            }

            Console.WriteLine("-------------------------------------");

            var mediaPorCategoria1 = context.Produtos
                                    .GroupBy(p => p.Categoria.Nome)
                                    .Select(categoriaGrupo => new
                                        {
                                            Categoria = categoriaGrupo.Key,
                                            MediaGrupo = categoriaGrupo.Average(p => p.Preco)
                                        });

            foreach(var media in mediaPorCategoria1){
                Console.WriteLine($"Categoria: {media.Categoria}\n Média: R$ {media.MediaGrupo}");
            }

        }
    }

}
