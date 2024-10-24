namespace Laboratorio5;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
       Circulo circ1 = new Circulo();
        Console.WriteLine(circ1);
        Circulo circ2 = new Circulo(2.4, 5, 3);
        Console.WriteLine(circ2);
        CirculoColorido circ3 = new CirculoColorido();
        Console.WriteLine(circ3);
        CirculoColorido circ4 = new CirculoColorido(1.5, 3.1, 1, "vermelho");
        Console.WriteLine(circ4);

        //EXERCICIOS
        //1) 
        circ4.CentroX = 10.0;
        circ4.CentroY = 20.0;
        circ4.Raio = 5.0;
        circ4.Cor = "azul";

        Console.WriteLine("Depois de modificar as propriedades de circ4:");
        Console.WriteLine($"CentroX: {circ4.CentroX}, CentroY: {circ4.CentroY}, Raio: {circ4.Raio}, Cor: {circ4.Cor}");

        circ3.CentroX = 7.7;
        circ3.Cor = "verde";

        Console.WriteLine("Depois de modificar as propriedades de circ3:");
        Console.WriteLine(circ3);

        //2)
         // Testando a classe CirculoColoridoPreenchido
        CirculoColoridoPreenchido circ5 = new CirculoColoridoPreenchido();
        Console.WriteLine(circ5);  // Saída com valores padrão

        // Instanciando com valores específicos
        CirculoColoridoPreenchido circ6 = new CirculoColoridoPreenchido(1.5, 2.3, 4.5, "vermelho", Color.Yellow);
        Console.WriteLine(circ6);

        // Modificando a cor de preenchimento
        circ6.CorPreenchimento = Color.Blue;
        Console.WriteLine($"Depois de modificar a cor de preenchimento: {circ6}");

        // 3)
        // Criando um array de objetos do tipo Circulo
        Circulo[] circulos = new Circulo[3];

        // Preenchendo o array com instâncias de Circulo, CirculoColorido e CirculoColoridoPreenchido
        circulos[0] = new Circulo(1, 2, 3); // Instância de Circulo
        circulos[1] = new CirculoColorido(4, 5, 6, "azul"); // Instância de CirculoColorido
        circulos[2] = new CirculoColoridoPreenchido(7, 8, 9, "vermelho", Color.Yellow); // Instância de CirculoColoridoPreenchido

        // Percorrendo o array e imprimindo os dados de cada objeto
        foreach (var circulo in circulos)
        {
            Console.WriteLine("Circulo do array: ");
            Console.WriteLine(circulo);
        }

    }
}
