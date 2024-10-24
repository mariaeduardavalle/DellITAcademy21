namespace _01_conversaoDeTipo;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        int i = 123;
        Console.WriteLine("i = "+i);
        long l = i;
        Console.WriteLine("l = "+l);
        short s = (short)i;
        Console.WriteLine("m = "+s);

        double d = 1.2579;
        Console.WriteLine("d ="+d);

        float f = (float)d;
        Console.WriteLine("f ="+f);

        l = (long)d;
        Console.WriteLine("l ="+l);

        i = (int)d;
        Console.WriteLine("i ="+i);

        int x=0;
        Console.WriteLine("x ="+x);
        int? y=null;
        Console.WriteLine("y= "+y);

        string str = "Dell";
        Console.WriteLine("str ="+str);
        string? str2=null;
        Console.WriteLine("str= "+str2);
        Console.WriteLine("str= "+str.ToUpper());
        Console.WriteLine("str= "+str2?.ToUpper());

        int[] vetor = new int[5];
        int[,] matriz = {{1,2},{3,4}};
        int[][] jagged = new int[2][];
        jagged[0]= new int[2];
        jagged[1]= new int[2];
        for(int lin=0; lin<2; lin++){
            vetor[lin]= lin*10;
            for(int col=0; col<2; col++){
                jagged[lin][col]= (lin+col+1)*10;
            }
        }

        foreach(int valor in vetor){
            Console.WriteLine("Vetor-> "+valor);
        }

        for(int lin=0; lin<2; lin++){
            for(int col=0; col<2; col++){
                Console.WriteLine("Matriz-> ["+lin+"]["+col+"] = "+ matriz[lin,col]);
            }
        }

        for(int lin=0; lin<2; lin++){
            for(int col=0; col<2; col++){
                Console.WriteLine("Jagged-> ["+lin+"]["+col+"] = "+ jagged[lin][col]);
            }
        }


    }
}
