public class ContaCorrente : Conta
{
    public ContaCorrente(string t) : base(t) { }

    public override string Id
    {
        get { return this.Titular + "(CC)"; } // CC para indicar Conta Corrente
    }

    public void ChequeEspecial(decimal valor)
    {
        Console.WriteLine($"Cheque especial de {valor:C2} utilizado por {Titular}");
        Depositar(valor);
    }
}
