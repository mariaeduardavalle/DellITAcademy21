using System;

class ContaCorrente
{
    // Atributos privados
    private decimal saldo;
    private string titular;
    private DateTime dataCriacao;

    private decimal acumuladorSaldo;  // Para armazenar a soma dos saldos após cada operação
    private int numeroOperacoes;      // Para contar o número de operações (depósito e saque)

    // Propriedade para acessar o saldo
    public decimal Saldo
    {
        get { return saldo; }
    }

    // Propriedade para acessar o nome do titular
    public string Titular
    {
        get { return titular; }
    }

    // Propriedade para acessar a data de criação da conta
    public DateTime DataCriacao
    {
        get { return dataCriacao; }
    }

    // Propriedade para acessar o saldo médio
    public decimal SaldoMedio
    {
        get
        {
            if (numeroOperacoes == 0)
            {
                return 0;  // Evita divisão por zero
            }
            return acumuladorSaldo / numeroOperacoes;
        }
    }

    // Construtor que inicializa o saldo e o nome do titular, e define a data de criação
    public ContaCorrente(decimal val, string nomeTitular)
    {
        saldo = val;
        titular = nomeTitular;
        dataCriacao = DateTime.Now;

        // Inicializando o acumulador e o contador de operações
        acumuladorSaldo = saldo;
        numeroOperacoes = 1;  // Conta a operação inicial (o depósito inicial)
    }

    // Método para realizar depósitos
    public void Depositar(decimal val)
    {
        saldo += val;  // Atualiza o saldo
        AtualizarSaldoMedio();  // Atualiza o acumulador de saldo e o contador de operações
    }

    // Método para realizar saques
    public void Sacar(decimal val)
    {
        saldo -= val;  // Atualiza o saldo
        AtualizarSaldoMedio();  // Atualiza o acumulador de saldo e o contador de operações
        Console.WriteLine("Saldo na conta: " + saldo);
    }

    // Método para atualizar o acumulador de saldo e o número de operações
    private void AtualizarSaldoMedio()
    {
        acumuladorSaldo += saldo;  // Acumula o saldo atual
        numeroOperacoes++;         // Incrementa o contador de operações
    }
}