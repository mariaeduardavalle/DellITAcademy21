namespace Laboratorio7;

class Program
{
    static void Main(string[] args)
    {
        IEstadoBinario[] lista = new IEstadoBinario[3];

        lista[0] = new Lampada(110, 60);
        lista[0].Ligar();
        lista[1] = new TermometroEletrico();
        lista[2] = new Ventilador(220, 80);
        lista[2].Ligar();
        lista[2].Desligar();

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("\nAparelho "+i+": "+lista[i].Estado);
        }
    }
}
