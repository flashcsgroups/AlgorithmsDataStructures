using System;

namespace AlgorithmsDataStructures.Algorithms.HacherRank
{
    class DiagonalDifference
    {
        static int diagonalDifference(int[,] arr)
        {
            int rowCount = arr.GetLength(0);
            int columnsCount = arr.GetLength(1);
            int sumLeftD, sumRightD;
            sumLeftD = sumRightD = 0;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    if (i == j)
                    {
                        sumLeftD += arr[i, j];
                    }
                }               
            }

            for (int i = rowCount - 1; i > 0; i--)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    if (i == j)
                    {
                        sumRightD += arr[i, j];
                    }
                }
            }
            //return sumLeftD;
            return Math.Abs(sumLeftD - sumRightD);
        }

        static void Main()
        {
            int[,] imas = new int[,] { 
                                         { 11, 2, 4 },
                                         { 4, 5, 6, },
                                         { 10, 8, -12}       
                                     };
            Console.WriteLine("{0}, {1}", imas.GetLength(0), imas.GetLength(1));
            Console.WriteLine(diagonalDifference(imas));
            //
            Console.ReadLine();
        }
    }
}
