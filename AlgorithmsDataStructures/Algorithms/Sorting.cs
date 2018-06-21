using System;

namespace AlgorithmsDataStructures.Algorithms
{
    /// <summary>
    /// Базовый класс, предоставляющий доп. функционал своим потомкам.
    /// </summary>
    /// <typeparam name="TElement">Параметр типа, заданный при объявлении экземпляров Sorting</typeparam>
    abstract class Sorting<TElement>
    {
        #region Свойства

        /// <summary>
        /// Подсчет количества сравнений элементов.
        /// </summary>
        protected int CountIteration { get; set; }

        /// <summary>
        /// Подсчет количества выполненных замен.
        /// </summary>
        protected int CountSwap { get; set; }

        #endregion

        #region Методы

        /// <summary>
        /// Базовый метод сортировки массива Array,
        /// использущий встроенный алгоритм.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Обобщенный тип массива на вход методу</param>
        public virtual void Sort(TElement[] array)
        {
            Array.Sort(array);
        }

        /// <summary>
        /// Для реализации узкоспециализированной сортировки.
        /// </summary>
        protected abstract void Sort();

        /// <summary>
        /// Функция перестановки элементов в массиве обобщенного типа TElement.
        /// </summary>
        protected virtual void Swap(TElement[] elements, int left, int right)
        {
            //суть алгоритма
            {
                //во временной переменной запомнить значение первого аргумента. 
                TElement temp = elements[left];
                // первому значению присвоить второй аргумент.
                elements[left] = elements[right];
                // а второму значение первого из временной переменной!
                elements[right] = temp;
                CountSwap++;
            }
        }

        /// <summary>
        /// Выполняет сравнение кто из двух элементов меньше.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>По-умолчанию false</returns>
        protected abstract bool Less(TElement a, TElement b);

        /// <summary>
        /// Проверка, что массив отсортирован.
        /// </summary>
        /// <param name="elements"></param>
        /// <returns>true/false</returns>
        protected abstract bool isSorted();

        /// <summary>
        /// Печать массива.
        /// </summary>
        protected abstract void PrintArray();

        /// <summary>
        /// Статистика для вычисления сложности алгоритма.
        /// </summary>
        protected virtual void RuntimeEvaluationArray()
        {
            Console.WriteLine(
                $"Общее число сравнений сортировки = {CountIteration},\n" +
                $"Общее числов замен в массиве = {CountSwap}."
                );
        }

        #endregion
    }
}
