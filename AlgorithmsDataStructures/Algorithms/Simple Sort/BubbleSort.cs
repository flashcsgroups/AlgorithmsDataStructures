using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures.Algorithms
{
    /// <summary>
    /// Сортировка пузырьком. Проходиим массив слево направо.
    /// Элементы "всплывают" от наименьшего к  наибольшему слева направо.
    /// </summary>
    /// <remarks>
    /// Алгоритм:
    /// * Берем i-й элемент и сравниваем со всеми, начиная с i+1.
    /// * Если i > i+1, то меняем местами.
    /// * Так, циклически попарно сравниваем все элементы между собой.
    /// </remarks>
    class BubbleSort : Sorting<int>
    {
        #region Поля и свойства 

        /// <summary>
        /// Инкапсулирует сортируемый массив.
        /// </summary>
        int[] MyArray { get; set; }

        #endregion

        #region Конструкторы
        /// <summary>
        /// Конcтруктор по-умолчанию.
        /// </summary>
        public BubbleSort()
        {
            // Дефолтный массив для сортировки
            MyArray = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        }

        /// <summary>
        /// С инициализацией свойства.
        /// </summary>
        /// <param name="mas"></param>
        public BubbleSort(int[] mas)
        {
            MyArray = mas;
        }

        #endregion

        #region Методы
        /// <summary>
        /// Реализуем абстрактный метод проверки отсортированности массива.
        /// Если если есть хоть один элемент меньше предыдущего, то false. 
        /// </summary>
        /// <returns>Результат проверки true/false</returns>
        protected override bool isSorted()
        {
            for (int i = 1; i < MyArray.Length; i++)
            {
                if (Less(MyArray[i], MyArray[i - 1]))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Реализуем абстрактный метод сравнения.
        /// </summary>
        /// <param name="a">Левый операнд</param>
        /// <param name="b">Правый операнд</param>
        /// <returns>Результат сравнения true/false</returns>
        protected override bool Less(int a, int b)
        {
            if (a < b)
            {
                CountIteration++;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Перегруженная версия для печати всех массивов.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        protected override void PrintArray()
        {
            Console.WriteLine();
            foreach (var i in MyArray)
            {
                Console.Write(i + " ");
            }
        }

        /// <summary>
        /// Алгоритм сортировки Пузырьком.
        /// </summary>
        protected override void Sort()
        {
            for (int i = 0; i < MyArray.Length; i++)
            {
                for (int j = i + 1; j < MyArray.Length; j++)
                {
                    if (Less(MyArray[j], MyArray[i]))
                    {
                        base.Swap(MyArray, i, j);
                    }
                }
            }
        }

        /// <summary>
        /// Сортировка всех массивов Пузырьком.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void Sort<T>(List<T> list) where T : BubbleSort
        {
            foreach (T item in list)
            {
                item.Sort();
            }
        }

        /// <summary>
        /// Печать всех массивов.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void PrintArray<T>(List<T> list) where T : BubbleSort
        {
            foreach (T item in list)
            {
                item.PrintArray();
            }
        }

        /// <summary>
        /// Проверка отсортированы ли массивы.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void IsSortedAll<T>(List<T> list) where T : BubbleSort
        {
            foreach (var item in list)
            {
                Console.Write(item.isSorted() + " ");
            }
        }

        /// <summary>
        /// Получение статистики параметров временной сложности для всех массивов.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void RuntimeEvaluationArray<T>(List<T> list) where T : BubbleSort
        {
            foreach (var item in list)
            {
                Console.WriteLine($"Длина массива = {item.MyArray?.Length}");
                item.RuntimeEvaluationArray();
                Console.WriteLine();
            }
        }

        #endregion
    }
}
