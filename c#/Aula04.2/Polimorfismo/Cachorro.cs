class Cachorro : Animal{

    public Cachorro(string nome, decimal peso): base(nome,peso){}

    public override string ToString()
    {
        return "A CLASSE É A "+ this.GetType().Name+ "\n";
    }

    public new string print(){
        return "texto a partir da classe cachorro com new";
    }

    public void pega(){
        Console.WriteLine("Partiu graveto");
    }
}