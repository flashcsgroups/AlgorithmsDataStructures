using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures.Algorithms
{
    /// <summary>
    /// Сортировка выбором. Проходим массив слево направо.
    /// На каждой i-ой итерации находим мин. элемент и помещаем в начало.
    /// </summary>
    /// <remarks>
    /// Алгоритм:
    /// * На i-ой операции считаем элемент с текущим индексом минимальным и сравниваем с остальными.
    /// * Если найден минимальный, то текущему присваиваем найденный и меняем элементы местами.
    /// * Так, циклически проходим до конца структуры данных.
    /// 
    /// Соблюдение инварианта (неизменяемость) базируется на 2 правилах:
    /// 1. То что слева  от текущего не должно меняться, т.к, отсортировано.
    /// 2. То что справа от текущего не может быть меньше левой части.
    /// </remarks>
    class SelectionSort : Sorting<int>
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
        public SelectionSort()
        {
            // Дефолтный массив для сортировки
            MyArray = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        }

        /// <summary>
        /// С инициализацией свойства.
        /// </summary>
        /// <param name="mas"></param>
        public SelectionSort(int[] mas)
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
        /// Алгоритм сортировки выбором.
        /// </summary>
        protected override void Sort()
        {
            int min;

            for (int i = 0; i < MyArray.Length; i++)
            {
                min = i;     // объявляем индекс минимального элемента равным индексу текущего элемента цикла;
                             // перебираем в цикле оставшиеся элементы массива и попарно сравниваем пока не найдем минимальный, 
                             // индекс которого присваиваем min и меняем элементы местами.
                for (int j = i + 1; j < MyArray.Length; j++)
                {
                    if (Less(MyArray[j], MyArray[min]))
                    {
                        min = j;
                    }
                }
                base.Swap(MyArray, i, min);
            }
        }

        /// <summary>
        /// Перегруженная версия для сортировки всех массивов.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void Sort<T>(List<T> list) where T : SelectionSort
        {
            foreach (T item in list)
            {
                item.Sort();
            }
        }

        /// <summary>
        /// Вызов родительской сортировки.
        /// </summary>
        /// <param name="array">Входной массив</param>
        public override void Sort(int[] array)
        {
            // Встроенный метод сортировки C# (метод быстрой сортировки).
            base.Sort(array);
            Console.WriteLine();
            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
        }

        /// <summary>
        /// Печать отсортированного массива.
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
        public static void PrintArray<T>(List<T> list) where T : SelectionSort
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
        public static void IsSortedAll<T>(List<T> list) where T : SelectionSort
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
        public static void RuntimeEvaluationArray<T>(List<T> list) where T : SelectionSort
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
