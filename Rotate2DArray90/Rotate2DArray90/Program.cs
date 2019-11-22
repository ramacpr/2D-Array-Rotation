using System;

namespace Rotate2DArray90
{
    class Program
    {
        static int sizeN = 10;
        static void Main(string[] args)
        {
            Console.WriteLine("---Rotate 2D Array by 90 degrees---");

            int[,] arr = new int[sizeN, sizeN];
            int cnt = 10;
            for (int i = 0; i < sizeN; i++)
                for (int j = 0; j < sizeN; j++)
                    arr[i, j] = cnt = cnt + 1;

            Console.WriteLine("---- BEFORE ----");
            for (int i = 0; i < sizeN; i++)
            {
                for (int j = 0; j < sizeN; j++)
                    Console.Write(" " + arr[i, j]);
                Console.WriteLine(" ");
            }

            RotateBy90(ref arr, sizeN);

            Console.WriteLine("---- AFTER ----");
            for (int i = 0; i < sizeN; i++)
            {
                for (int j = 0; j < sizeN; j++)
                    Console.Write(" " + arr[i, j]);
                Console.WriteLine(" ");
            }

        }

        static void RotateBy90(ref int[,] arr, int N)
        {
            int itrRowUpto, itrColUpto;
            itrRowUpto = N / 2 - 1;
            if (N % 2 == 0) // even
            {
                itrColUpto = itrRowUpto;
            }
            else // odd
            {
                itrColUpto = N / 2;
            }

            for(int rowIndex = 0; rowIndex <= itrRowUpto; rowIndex++)
                for(int colIndex = 0; colIndex <= itrColUpto; colIndex++)               
                    Rotate(ref arr, rowIndex, colIndex, N);            
        }

        static int compliment(int n, int N)
        {
            return N - n - 1;
        }

        static void Rotate(ref int[,] arr, int rowIndex, int colIndex, int N)
        {
            int backup = arr[rowIndex, colIndex];
            int tmp;
            int new_rowIndex;
            int new_colIndex;

            for(int loop = 0; loop < 4; loop++)
            {
                new_rowIndex = colIndex;
                new_colIndex = compliment(rowIndex, N);
                if (new_colIndex >= N || new_colIndex < 0)
                {
                    Console.WriteLine("ERROR!!!");
                    return;
                }

                // swap backup and new row col data 
                tmp = backup;
                backup = arr[new_rowIndex, new_colIndex];
                arr[new_rowIndex, new_colIndex] = tmp;

                //
                colIndex = new_colIndex;
                rowIndex = new_rowIndex;                
            }

            
        }

    }
}
