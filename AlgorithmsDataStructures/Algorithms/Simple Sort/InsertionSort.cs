using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures.Algorithms
{
    /// <summary>
    ///  Сортировка вставками. Проходим массив справа налево.
    ///  На 
    /// </summary>
    /// <remarks>
    /// Соблюдение инварианта (неизменяемость) базируется на 2 правилах:
    /// 1. То что слева  от текущего находится в порядке возрастания.
    /// 2. То что справа от текущего еще не рассматривалось.
    /// Алгоритм:
    /// * В начале цикла полагаем 1-й элемент первым в отсортированном подмассиве и шагаем с со 2-го.
    /// * Сравниваем элементы справа налево от текущего.
    /// * Если текуший меньше того, что слева из подмассива, то меняем местами.
    /// </remarks>
    class InsertionSort : Sorting<int>
    {
        #region Поля и свойства
        /// <summary>
        /// Представляет сортируемый массив
        /// </summary>
        int[] MyArray { get; set; }

        #endregion

        #region Конструкторы
        /// <summary>
        /// Конcтруктор по-умолчанию.
        /// </summary>
        public InsertionSort()
        {
            // Дефолтный массив для сортировки
            MyArray = new int[] {6, 1, 2, 3, 4, 5, 7, 8, 9, 10 };
            CountIteration = CountSwap = 0;
        }

        /// <summary>
        /// С инициализацией свойства.
        /// </summary>
        /// <param name="mas"></param>
        public InsertionSort(int[] mas)
        {
            MyArray = mas;
            CountIteration = CountSwap = 0;
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
        /// Алгоритм сортировки Выбором.
        /// </summary>
        protected override void Sort()
        {
            for (int i = 1; i < MyArray.Length; i++)
            {
                for (int j = i; j > 0 && MyArray[j] < MyArray[j-1]; j--)
                {
                    if (Less(MyArray[j], MyArray[j - 1]))
                    {
                        base.Swap(MyArray, j, j - 1);                      
                    }
                }
            }
        }

        /// <summary>
        /// Перегруженная версия для сортировки всех массивов.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void Sort<T>(List<T> list) where T : InsertionSort
        {
            foreach (T item in list)
            {
                item.Sort();
            }
        }

        /// <summary>
        /// Вывод на печать отсортированного массива.
        /// </summary>
        protected override void PrintArray()
        {
            Console.WriteLine();
            foreach (var i in MyArray)
            {
                Console.Write(i + " ");
            }
        }

        /// <summary>
        /// Перегруженная версия для печати всех массивов.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void PrintArray<T>(List<T> list) where T : InsertionSort
        {
            foreach (T item in list)
            {
                item.PrintArray();
            }
        }

        /// <summary>
        /// Проверка, что все массивы отсортированы.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name=""></param>
        public static void IsSortedAll<T>(List<T> list) where T : InsertionSort
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
        public static void RuntimeEvaluationArray<T>(List<T> list) where T : InsertionSort
        {
            foreach (var item in list)
            {
                Console.WriteLine($"Длина массива = {item.MyArray?.Length}\n");
                item.RuntimeEvaluationArray();
                Console.WriteLine();
            }
        }

        #endregion
    }
}
