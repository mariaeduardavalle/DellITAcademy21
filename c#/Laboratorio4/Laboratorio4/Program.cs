namespace Laboratorio4;

class Program
{
    static void Main(string[] args)
    {
        ContaCorrente minhaConta = new ContaCorrente(340, "Maria Eduarda");
        Console.WriteLine($"Titular: {minhaConta.Titular}");
        Console.WriteLine($"Data de criação: {minhaConta.DataCriacao}");
        Console.WriteLine($"Saldo inicial: {minhaConta.Saldo}");
        minhaConta.Depositar(100);
        Console.WriteLine(minhaConta.SaldoMedio);
        minhaConta.Depositar(150);
        minhaConta.Sacar(30);
        Console.WriteLine(minhaConta.SaldoMedio);
        minhaConta.Sacar(50);
        Console.WriteLine(minhaConta.SaldoMedio);
    }
}
