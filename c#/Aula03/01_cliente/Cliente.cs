class Cliente{

    private string nome;

    private decimal limiteCredito;

    private uint ClienteID;

    public string Propriedade{
        get{return "algo";}

    }

    public const string umTexto = " texto ";

    public void aumentaLimite(decimal valor){
        this.limiteCredito+=valor;
        Console.WriteLine(this+" ; limite=> "+ this.limiteCredito);
    }

    public void metodoOut01( int x, int y, int w){
        w=x+y;
    }

    public void metodoOut02(int x, int y, out int w){
        w=x+y;
    }

    /* ERRO 
    public void metodoOut03(int x, int y, out int w){
        w=x+y+w;
    }*/

    public void metodoRef04(int x, int y, ref int w){
        w=x+y+w;
    }

    public void metodoRef05(int x, int y, ref int w){
        w=x+y;
    }

   /* public void metodoParam01(params int [] valores){
        int resultado=0;
        foreach(int i in valores){
            resultado+=1;
        return resultado;
        }
            
        
    }*/
}