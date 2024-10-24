class Animal{

    public string Nome{ //propriedade
        get;
        protected set;
    }

    public string Especie{
        get;
        //protected set;
    }

    public string Classificacao{
        get;
        protected set;
    }
    
    public Animal(string nome, string especie, string classificacao){
        this.Nome = nome;
        this.Especie = especie;
        this.Classificacao = classificacao;
    }

    public Animal(string infounica){
        this.Nome=infounica;
        this.Especie=infounica;
        this.Classificacao=infounica;
    }
    public void setClassificacao(string classe){
        this.Classificacao=classe;
    }

    public virtual string Print(){
        string resultado;
        resultado = this.GetType().Name + "{\n";
        resultado +=" nome:" + this.Nome + ",\n";
        resultado +=" espécie:" + this.Especie + ",\n";
        resultado +=" classificação:" + this.Classificacao + ",\n";
        return resultado;
    }

    public override string ToString()
    {
        return this.GetType().Name+"-> ("+this.Nome+")";
    }


}