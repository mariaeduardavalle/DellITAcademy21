class Cachorro : Animal{

    public string Raca{
        get;
        private set;
    }

    public Cachorro(): base("sem detalhes na criacao"){
        this.Raca="stdr";
    }

    public Cachorro(string nome, string especie, string classificacao, string raca): base(nome, especie, classificacao){
        this.Raca=raca;
    }
    public void alteraRaca(string raca){
        this.Raca=raca;
    }

    public void alteraNome(string nome){
        this.Nome=nome;
    }

    public void alteraClassificacao(string classificacao){
        setClassificacao(classificacao);
        Raca="uma nova raca";
    }

    public new string Print(){
        string result;
        result= this.GetType().Name + "{\n";
        result+=" nome:" + this.Nome + ",\n";
        result +=" espécie:" + this.Especie + ",\n";
        result +=" classificação:" + this.Classificacao + ",\n";
        result +=" raça:" + this.Raca + ",\n";
        return result;
    }

    public override string ToString()
    {
        return base.ToString()+ " \n au au au au";
    }
} 

