namespace Laboratorio2;

class Program
{
    static void Main(string[] args)
    {
        int[] array = new int[5] { 10, 20, 30, 40, 50 };
        int i;
        for (i = 0; i < 5; i++)
        {
        Console.WriteLine("Indice = " + i + " & Valor = " + array[i]);
        }

        string[] str = new string[3];
        int iStr;
        str[0] = "Um";
        str[1] = "Dois";
        str[2] = "Tres";
        for (iStr = 0; iStr < 3; iStr++)
        {
        Console.WriteLine("Indice = " + iStr + " & Valor = " + str[iStr]);
        }

        DateTime[] dt = new DateTime[2];
        int iDate;
        dt[0] = new DateTime(2002, 5, 1);
        dt[1] = new DateTime(2002, 6, 1);
        for (iDate = 0; iDate < 2; iDate++)
        {
        Console.WriteLine("Indice = " + iDate + " & Data = " + 
        dt[iDate].ToShortDateString());
        }

        //EXERCICIOS

        //1)
        int tamanho = 100;
        int[] array1 = new int[tamanho];

        for(int j=0; j<tamanho; j++)
        {
            array1[j] = j+1;
        }

        int[] array2 = new int[tamanho];

        for(int j=0; j<tamanho; j++)
        {
            array2[j]= array1[j];
        }

        for(int j=0; j<tamanho; j++){
            Console.WriteLine("Indice = " + j + " & Valor = " + array1[j]);
        }

        Console.WriteLine("\n\n\n");

        for(int j=0; j<tamanho; j++){
            Console.WriteLine("Indice = " + j + " & Valor = " + array2[j]);
        }

        //2) VERSÃO MULTIDIMENSIONAL

        int[,] matriz = new int[5,5]
        {
            {1,2,3,4,5},
            {6,7,8,9,10},
            {11,12,13,14,15},
            {16,17,18,19,20},
            {21,22,23,24,25}
        };

        for(int coluna=0; coluna<5; coluna++){
            int somaColuna=0;
            for(int linha=0; linha<5; linha++){
                somaColuna += matriz[linha,coluna];
            }
            Console.WriteLine($"\nSoma da coluna {coluna + 1}: {somaColuna}");
        }

        //VERSAO JAGGED
       int[][] matriz1 = new int[5][]
        {
            new int[] { 1, 2, 3, 4, 5 },
            new int[] { 6, 7, 8, 9, 10 },
            new int[] { 11, 12, 13, 14, 15 },
            new int[] { 16, 17, 18, 19, 20 },
            new int[] { 21, 22, 23, 24, 25 }
        };

        // Calculando a soma de cada coluna
        for (int coluna = 0; coluna < 5; coluna++)
        {
            int somaColuna = 0;
            for (int linha = 0; linha < 5; linha++)
            {
                somaColuna += matriz1[linha][coluna];
            }
            Console.WriteLine($"\nSoma da coluna {coluna + 1}: {somaColuna}");
        }




    }
}
