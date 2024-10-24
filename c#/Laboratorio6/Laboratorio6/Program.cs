namespace Laboratorio6;

class Program
{
    static void Main(string[] args)
    {
        // Criando instâncias de vários tipos de conta
        ContaCorrente cc1 = new ContaCorrente("Maria");
        ContaPoupanca cp1 = new ContaPoupanca(0.05m, new DateTime(2024, 10, 18), "João");
        
        // Testando métodos das contas individuais
        cc1.Depositar(500);
        cc1.Sacar(200);
        cc1.ChequeEspecial(100);
        Console.WriteLine($"Saldo de {cc1.Titular}: {cc1.Saldo:C2}");
        
        cp1.Depositar(1000);
        cp1.AdicionarRendimento();
        Console.WriteLine($"Saldo de {cp1.Titular}: {cp1.Saldo:C2}");

        // Criando uma coleção de objetos do tipo Conta
        List<Conta> contas = new List<Conta>();

        // Adicionando contas à coleção
        contas.Add(cc1);
        contas.Add(cp1);
        contas.Add(new ContaPoupanca(0.04m, new DateTime(2024, 11, 1), "Pedro"));
        contas.Add(new ContaCorrente("Ana"));

        // Percorrendo a coleção e chamando métodos sobre cada conta
        foreach (Conta conta in contas)
        {
            Console.WriteLine($"Id da conta: {conta.Id}");
            Console.WriteLine($"Saldo atual: {conta.Saldo:C2}");

            // Testando depósito e saque
            conta.Depositar(200);
            conta.Sacar(50);
            Console.WriteLine($"Novo saldo de {conta.Titular}: {conta.Saldo:C2}");

            // Verificando se a conta é uma poupança para aplicar rendimento
            if (conta is ContaPoupanca cp)
            {
                cp.AdicionarRendimento();
                Console.WriteLine($"Saldo de {cp.Titular} após rendimento: {cp.Saldo:C2}");
            }
            Console.WriteLine("-----------------------------");
        }
    }
}
