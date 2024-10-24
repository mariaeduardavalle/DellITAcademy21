// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Cliente c = new Cliente();
/* Console.WriteLine(c);
Console.WriteLine(Cliente.umTexto);

c.aumentaLimite(1000.99M);

Lampada l = new Lampada();
Console.Write("Lampada esta ligada? "+ l.ligada());
l.trocaEstado();
Console.Write("Lampada esta ligada? "+ l.ligada());

for(int i=0; i<60; i++){
    l.trocaEstado();
    Console.WriteLine("Lampada esta ligada? "+ l.ligada());
} */

//MODIFICADORES DE METODOS(OUT/REF/PARAM)
int a =10;
int b=20;
int d=5;

c.metodoOut01(a,b,d);
Console.WriteLine(" => "+d);

c.metodoOut02(a,b, out d);
Console.WriteLine(" => "+d);

//c.metodoOut03(a,b, out d);
//Console.WriteLine(" => "+d);

c.metodoRef04(a,b, ref d);
Console.WriteLine(" => "+d);

int e;
//ERRO... a variavel ref precisa ser inicializada para ser passada por parametro
//c.metodoOut05(a,b, ref e);
//Console.WriteLine(" => "+e);

//int [] listaDeValores = new int [5]{1,2,3,4,5};
//Console.WriteLine(c.metodoParam01(1,2,3));
//Console.WriteLine(c.metodoParam01(1,2,7,34,67,4,21,5));


Console.WriteLine(c.Propriedade);


