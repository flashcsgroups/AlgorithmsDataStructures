using System;
using System.Threading;

namespace AlgorithmsDataStructures.Algorithms.Recursive
{
    class Fibonachy
    {
        /// <summary>
        /// Размерность для расчета фиббоначи
        /// </summary>
        public static int N { get; set; }

        /// <summary>
        /// Счетчик итераций алгоритма
        /// </summary>
        public static int Count { get; set; }

        static int[] temp;

        /// <summary>
        /// Примитивный алгоритм вычисления чисел Фиббоначи.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int Fib(int n)
        {
            if (n == 0)
            {
                Count++;
                return 1;
            }
            if (n == 1)
            {
                Count++;
                return 1;
            }
            Count++;
            return Fib(n - 1) + Fib(n - 2);
        }

        /// <summary>
        /// Перегружаем функцию Fib через ref
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int refFib(int n)
        {
            temp = new int[1000];

            if (n == 0)
            {
                Count++;
                return 1;
            }
            if (n == 1)
            {
                Count++;
                return 1;
            }
            if (temp[n] > 0)

            {
                Count++;
                return temp[n];
            }
            Count++;
            return temp[n] = Fib(n - 1) + Fib(n - 2);
        }

        /// <summary>
        /// Распечатка сведений по вычисленном числе фиббоначи.
        /// </summary>
        public static void Print()
        {
            Console.Write("Введите число для подсчета Фиббоначи: ");
            N = int.Parse(Console.ReadLine());
            Console.WriteLine($"Число Фиббоначи = {Fib(N)},\n" +
                $"Число итераций = {Count}");
        }

        /// <summary>
        /// Перегрузка печати для второй реализации подсчета
        /// </summary>
        public static void refPrint(int N)
        {
            Count = 0;
            Console.WriteLine($"Число Фиббоначи = {refFib(N)},\n" +
                $"Число итераций = {Count}");
        }

        /// <summary>
        /// Точка входа
        /// </summary>
        static void Main()
        {
            int N = 10;
            
            Print();
            Console.WriteLine("---------------------------------------");
            refPrint(N);
          

            //
            Console.ReadLine();
        }
    }
}
