using System;
using System.Collections.Generic;
using AlgorithmsDataStructures.Algorithms;

namespace AlgorithmsDataStructures
{
    class Program
    {
        /// <summary>
        /// Для заполнения массивов случайными числами.
        /// </summary>
        static Random random = new Random();

        /// <summary>
        /// Точка входа.
        /// </summary>
        static void Main()
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            //Console.WindowWidth = Console.LargestWindowWidth;
            Console.SetWindowPosition(0, 0);

            //инициализируем тестируемые массивы.
            int[] mas = { 5, 9, 1, 4, 0, 2 };
            int[] mas2 = new int[mas.Length];
            mas.CopyTo(mas2, 0);

            int[] masBubble = new int[mas2.Length];
            mas2.CopyTo(masBubble, 0);

            // массивы, заполненные случайным образом.
            RandomValue(out int[] mas3);
            RandomValue(out int[] mas4);
            RandomValue(out int[] mas5);

            #region Тест сортировки пузырьком.

            Console.WriteLine("--------------------***Тест сортировки пузырьком***--------------------");

            List<BubbleSort> listBubbleSorts = new List<BubbleSort>
            {
               new BubbleSort(masBubble),
               new BubbleSort(mas5),
               new BubbleSort()
            };

            Console.Write("Исходные массивы:\n");
            BubbleSort.PrintArray(listBubbleSorts);
            //
            Console.WriteLine("\n\tОтсортируем массивы методом выбора: ");
            BubbleSort.Sort(listBubbleSorts);
            BubbleSort.PrintArray(listBubbleSorts);
            //
            Console.Write($"\r\nМассивы отсортированы? -> ");
            BubbleSort.IsSortedAll(listBubbleSorts);
            //
            Console.WriteLine("\nПараметры временной сложности отсортированных массивов:\n");
            BubbleSort.RuntimeEvaluationArray(listBubbleSorts);

            #endregion

            #region Тест сортировки выбором.
            Console.WriteLine("--------------------***Тест сортировки выбором***--------------------");

            List<SelectionSort> listSelectionSorts = new List<SelectionSort>
            {
               new SelectionSort(mas),
               new SelectionSort(mas3),
               new SelectionSort()
            };

            Console.Write("Исходные массивы:\n");
            SelectionSort.PrintArray(listSelectionSorts);
            //
            Console.WriteLine("\n\tОтсортируем массивы методом выбора: ");
            SelectionSort.Sort(listSelectionSorts);
            SelectionSort.PrintArray(listSelectionSorts);
            //
            Console.Write($"\r\nМассивы отсортированы? -> ");
            SelectionSort.IsSortedAll(listSelectionSorts);
            //
            Console.WriteLine("\nПараметры временной сложности отсортированных массивов:\n");
            SelectionSort.RuntimeEvaluationArray(listSelectionSorts);

            #endregion

            #region Тест сортировки вставками.
            Console.WriteLine("--------------------***Тест сортировки вставками***--------------------");

            List<InsertionSort> listInsertionSorts = new List<InsertionSort>
            {
               new InsertionSort(mas2),
               new InsertionSort(mas4),
               new InsertionSort()
            };

            Console.Write("Исходные массивы:\n");
            InsertionSort.PrintArray(listInsertionSorts);
            //
            Console.WriteLine("\n\tОтсортируем массивы методом выбора: ");
            InsertionSort.Sort(listInsertionSorts);
            InsertionSort.PrintArray(listInsertionSorts);
            //
            Console.Write($"\r\nМассивы отсортированы? -> ");
            InsertionSort.IsSortedAll(listInsertionSorts);
            //
            Console.WriteLine("\nПараметры временной сложности отсортированных массивов:\n");
            InsertionSort.RuntimeEvaluationArray(listInsertionSorts);

            #endregion

            //
            Console.ReadLine();
        }

        /// <summary>
        /// Заполняет массив псевдослучайными целыми числами.
        /// </summary>
        /// <param name="vs">Массив, который заполняем</param>
        /// <returns></returns>
        public static int[] RandomValue(out int[] vs)
        {
            int lengt = random.Next(10, 20);

            vs = new int[lengt];

            for (int i = 0; i < vs.Length; i++)
            {
                vs[i] = random.Next(-lengt, lengt);
            }
            return vs;
        }
    }
}
