using System;
using System.Collections.Generic;

public abstract class Conta{

    private decimal saldo;
    private string titular;

    public Conta(string t)
    {
        titular = t;
    }
    public decimal Saldo
    {
        get { return saldo; }
    }
    public string Titular
    {
        get { return titular; }
    }

    public abstract string Id
    {
        get;
    }

    public virtual void Depositar(decimal valor)
    {
        saldo += valor;
    }
    public virtual void Sacar(decimal valor)
    {
        saldo -= valor;
    }
}