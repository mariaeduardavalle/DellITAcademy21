class Program
{

    static void Main(string[] args){

        byte b;
        b = byte.MaxValue;
        int i;
        i = int.MaxValue;
        long l;
        l = long.MaxValue;


        Console.WriteLine("Valor máximo de byte: "+b);
        Console.WriteLine($"Valor máximo de byte: {b}");

        Console.WriteLine("Valor máximo de int: "+i);

        Console.WriteLine("Valor máximo de long: "+l);

        string strPrimeira = "Alo ";
        string strSegunda = "Mundo";
        string strTerceira = strPrimeira + strSegunda;

        Console.WriteLine(strTerceira);

        int cchTamanho = strTerceira.Length;

        string strQuarta = "Tamanho = "+ cchTamanho.ToString();

        Console.WriteLine(strQuarta);

        Console.WriteLine(strTerceira.Substring(0,5));

        DateTime dt = new DateTime(2015, 04, 23);
        string strQuinta = dt.ToString();
        Console.WriteLine(strQuinta);

        // EXERCICIOS
        // 1)

        float f = 5.0F;
        Console.WriteLine(f);

        double d;
        d = double.MinValue;
        Console.WriteLine("\nTamanho mínimo de double: \n"+d);

        decimal dec = 4.5M;
        Console.WriteLine(dec);

        //2)
        string s1 = "Hello World!";
        Console.WriteLine(s1.PadLeft(20, '-'));

        string s2 = "Hello!";
        Console.WriteLine(string.Compare(s2, "Hello?"));

        //3)
        DateTime localDate = new DateTime(2010, 3, 14, 2, 30, 0, DateTimeKind.Local);
        long binLocal = localDate.ToBinary();
        if (TimeZoneInfo.Local.IsInvalidTime(localDate))
            Console.WriteLine("{0} is an invalid time in the {1} zone.",
                            localDate,
                            TimeZoneInfo.Local.StandardName);

        DateTime localDate2 = DateTime.FromBinary(binLocal);
        Console.WriteLine("{0} = {1}: {2}",
                            localDate, localDate2, localDate.Equals(localDate2));

         //4)
        int i1 = 10;
        float f1 = 0;
        f1 = i1; //conversão implícita, sem perda de dados.
        System.Console.WriteLine(f1);
        f1 = 0.5F;
        i1 = (int) f1; //conversão explícita, com perda de dados.
        System.Console.WriteLine(i1);

        //5)
        /* string stringInteiro = "123456789";
        int valorStringInteiro = Convert.ToInt32(stringInteiro);
        Console.WriteLine(valorStringInteiro);
        Int64 valorInt64 = 123456789;
        int valorInt = Convert.ToInt32(valorInt64);
        Console.WriteLine(valorInt);
        
        string stringInteiroGrande = "999999999999999999999999999999999999999999999";
        int valorStringInteiroGrande = Convert.ToInt32(stringInteiroGrande); */

        //6) 
        string stringInteiro = "123456789";
        int valorStringInteiro;
        bool conversao1 = Int32.TryParse(stringInteiro, out valorStringInteiro);
        Console.WriteLine("Conversão efetuada:" + conversao1 + " Valor: " + valorStringInteiro);
        string stringInteiroGrande = "999999999999999999999999999999999999999999999";
        int valorStringInteiroGrande;
        bool conversao2 = Int32.TryParse(stringInteiroGrande, out valorStringInteiroGrande);
        Console.WriteLine("Conversão efetuada:" + conversao2 + " Valor: " + valorStringInteiroGrande);
        string stringLetras = "abc";
        double valorStringLetras;
        bool conversao3 = Double.TryParse(stringLetras, out valorStringLetras);
        Console.WriteLine("Conversão efetuada:" + conversao3 + " Valor: " + valorStringLetras);

        //7)
        double valorFracionado = 4.7;
        int valorInteiro1 = (int) valorFracionado;
        int valorInteiro2 = Convert.ToInt32(valorFracionado);
        Console.WriteLine("Conversao explicita = " + valorInteiro1);
        Console.WriteLine("Conversao metodo Convert = " + valorInteiro2);
        
        //8)
        int x = 10;
        double y = 3.4;
        Console.WriteLine("{0} {1}",x,y);
        Console.WriteLine($"{x} {y}");


    }
}
