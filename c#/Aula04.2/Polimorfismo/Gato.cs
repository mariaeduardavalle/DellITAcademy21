class Gato : Animal{

    public Gato(string nomebichano, string pesoanimal): base(nomebichano,Decimal.Parse(pesoanimal)){}

    public override string ToString()
    {
        return "A CLASSE É o gatinho \n";
    }

    public new string print(){
        return "texto a partir da classe gatinho com new";
    }

    public void missi(){
            Console.WriteLine("ronronandooo");
    }


}