namespace Heranca;

class Program
{
    static void Main(string[] args)
    {
        Animal a = new("Chloe", "cão", "mamífero");
        Console.WriteLine(a);
        Console.WriteLine("a.especie = "+ a.Especie);
        Console.WriteLine("a.nome = "+ a.Nome);
        Console.WriteLine("a.classificção = "+ a.Classificacao+"\n");
        Console.WriteLine(a.Print());

        Console.WriteLine("-------------------");

        Cachorro c = new();
        Console.WriteLine(c);
        Console.WriteLine("\nc.especie = "+ c.Especie);
        Console.WriteLine("c.nome = "+ c.Nome);
        Console.WriteLine("c.classificção = "+ c.Classificacao);
        Console.WriteLine("c.raca = "+ c.Raca);
        Console.WriteLine(c.Print());

        c.alteraClassificacao("doguinho");
        Console.WriteLine(c.Print());
    }
    
}
