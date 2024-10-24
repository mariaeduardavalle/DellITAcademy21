class Lampada
{
    private bool estaligada;
    private int conta;
    private bool Lampadaestragada;

    public void trocaEstado(){
        if(!Lampadaestragada){
           estaligada = !estaligada;  
           conta++;
           if(conta> 50){
            Lampadaestragada=true;
           }
        }
        else {
            Console.WriteLine("Lampada estragou. ");
        }
       
    }

    public bool ligada(){

        return (!Lampadaestragada)&&(estaligada);
    }
}