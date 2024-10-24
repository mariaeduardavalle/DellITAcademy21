namespace Polimorfismo;

class Program
{
    static void Main(string[] args)
    {
        Animal a = new("toto", 12.5M);
        Console.WriteLine(a);
        Console.WriteLine(a.print());

        Console.WriteLine("---------------");

        a = new Cachorro("rex", 12.75M);
        Console.WriteLine(a);
        Console.WriteLine(a.print());

        Console.WriteLine("a é um animal? "+(a is Animal));
        Console.WriteLine("a é um cachorro? "+(a is Cachorro));
        Console.WriteLine("a é um gato? "+(a is Gato));

        if(a is Cachorro){
            Console.WriteLine("Atuando como cachorro \n");
            Console.WriteLine((a as Cachorro));
            Console.WriteLine((a as Cachorro)?.print());
            (a as Cachorro)?.pega();

        }

        a = new Gato("Tom", "2.45");
        Console.WriteLine(a);
        Console.WriteLine(a.print());

        Console.WriteLine("a é um animal? "+(a is Animal));
        Console.WriteLine("a é um cachorro? "+(a is Cachorro));
        Console.WriteLine("a é um gato? "+(a is Gato));

        if(a is Gato){
            Console.WriteLine("Atuando como gato \n");
            Console.WriteLine((a as Gato));
            Console.WriteLine((a as Gato)?.print());
            (a as Gato)?.missi();

        }
    }
}
