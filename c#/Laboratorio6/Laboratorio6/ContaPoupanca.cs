using System;

public class ContaPoupanca : Conta
{
    // Atributos adicionais
    private decimal taxaJuros;
    private DateTime dataAniversario;

    // Construtor que faz referência ao construtor da classe base
    public ContaPoupanca(decimal j, DateTime d, string t) 
        : base(t) // Chama o construtor da classe base (Conta) passando o titular
    {
        taxaJuros = j;
        dataAniversario = d;
    }

    // Propriedade para acessar a taxa de juros
    public decimal Juros
    {
        get { return taxaJuros; }
        set { taxaJuros = value; }
    }

    // Propriedade para acessar a data de aniversário da conta
    public DateTime DataAniversario
    {
        get { return dataAniversario; }
    }

    // Método para aplicar o rendimento da conta
    public void AdicionarRendimento()
    {
        DateTime hoje = DateTime.Now;
        if (hoje.Day == dataAniversario.Day && hoje.Month == dataAniversario.Month)
        {
            decimal rendimento = this.Saldo * taxaJuros;
            this.Depositar(rendimento); // Deposita o rendimento na conta
            Console.WriteLine($"Rendimento de {rendimento:C2} aplicado à conta de {this.Titular}");
        }
        else
        {
            Console.WriteLine("Não é a data de aniversário da conta, nenhum rendimento aplicado.");
        }
    }

    // Implementação da propriedade abstrata 'Id' herdada da classe base
    public override string Id
    {
        get { return this.Titular + "(CP)"; } // CP para indicar que é Conta Poupança
    }
}
