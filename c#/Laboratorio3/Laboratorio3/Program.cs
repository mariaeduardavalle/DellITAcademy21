namespace System.Collections.Generics;

class Program
{
    static void Main(string[] args)
    {
        //LISTA
       List<string> listaStrings = new List<string>();
       listaStrings.Add("Um");
       listaStrings.Add("Hello");
       listaStrings.Add("World");
       Console.WriteLine(listaStrings[0]);
       Console.WriteLine(listaStrings[1]);
       Console.WriteLine(listaStrings[2]);

        // FILA DE OBJETOS
       Queue<Object> q = new Queue<Object>();
        q.Enqueue(".Net Framework");
        q.Enqueue(new Decimal(123.456));
        q.Enqueue(654.321);
        Console.WriteLine(q.Dequeue());
        Console.WriteLine(q.Dequeue());
        Console.WriteLine(q.Dequeue());

        //FILA DE INTEIROS
        Queue<int> minhaFila = new Queue<int>();
        minhaFila.Enqueue(10);
        minhaFila.Enqueue(200);
        minhaFila.Enqueue(1000);
        Console.WriteLine(minhaFila.Dequeue());
        Console.WriteLine(minhaFila.Dequeue());
        Console.WriteLine(minhaFila.Dequeue());

        //DICIONARIO GENERICO
        Dictionary<int, string> paises = new Dictionary<int, string>();
        paises[44] = "Reino Unido";
        paises[33] = "França";
        paises[55] = "Brasil";
        Console.WriteLine("O código 55 é: {0}", paises[55]);
        foreach (var item in paises)
        {
        int codigo = item.Key;
        string pais = item.Value;
        Console.WriteLine("Código {0} = {1}", codigo, pais);
        }

        //EXERCICIOS
        //1)
        Console.Write("Digite o nome de um país para recuperar o DDI: ");
        string nomePais = Console.ReadLine();

        // Buscando o código DDI do país fornecido
        int codigoDDI = -1;
        foreach (var item in paises)
        {
            if (item.Value.Equals(nomePais, StringComparison.OrdinalIgnoreCase))
            {
                codigoDDI = item.Key;
                break;
            }
        }

        // Exibindo o resultado
        if (codigoDDI != -1)
        {
            Console.WriteLine($"O código DDI de {nomePais} é {codigoDDI}.");
        }
        else
        {
            Console.WriteLine($"País {nomePais} não encontrado.");
        }

        //2 e 3

        List<double> numeros = new List<double> { 1.5, 2.7, 3.1, 4.8, 5.0, 6.2 };

        // Chamando o método TotalAcimaMedia
        int totalAcimaMedia = TotalAcimaMedia(numeros);
        Console.WriteLine($"Número de elementos acima da média: {totalAcimaMedia}");

        // Chamando o método ListaAcimaMedia
        List<double> listaAcimaMedia = ListaAcimaMedia(numeros);
        Console.WriteLine("Elementos acima da média:");
        foreach (double numero in listaAcimaMedia)
        {
            Console.WriteLine(numero);
        }

    }

    static int TotalAcimaMedia(List<double> lista)
    {
        double media = lista.Average();  // Calcula a média da lista
        int total = 0;

        foreach (double numero in lista)
        {
            if (numero > media)
            {
                total++;  // Conta os elementos acima da média
            }
        }

        return total;  // Retorna o total de elementos acima da média
    }

    // Método para retornar uma nova lista com os elementos acima da média
    static List<double> ListaAcimaMedia(List<double> lista)
    {
        double media = lista.Average();  // Calcula a média da lista
        List<double> acimaMedia = new List<double>();

        foreach (double numero in lista)
        {
            if (numero > media)
            {
                acimaMedia.Add(numero);  // Adiciona o elemento à nova lista
            }
        }

        return acimaMedia;  // Retorna a lista de elementos acima da média
    }
}
