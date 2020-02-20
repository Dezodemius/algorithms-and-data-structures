using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorts
{
    /// <summary>
    /// Объект для работы с пузырьковой сортировкой.
    /// </summary>
    [SortingAlgorithm]
    public static class Bubble
    {
        #region Методы.
        
        /// <summary>
        /// Обыкновенная сортировка для общих типов.
        /// </summary>
        /// <param name="dataSet">Набор данных обобщённого типа.</param>
        /// <list type="T">Тип данных, из которых состоит коллекция.</list>
        [SortingMethod]
        public static void Simple(ref List<double> dataSet)
        {
            for (int i = 0; i < dataSet.Count(); i++)
            {
                for (int j = 0; j < dataSet.Count() - 1; j++)
                {
                    if (dataSet[j].CompareTo(dataSet[j + 1]) <= 0) 
                        continue;
                    
                    var temp = dataSet[j];
                    dataSet[j] = dataSet[j + 1];
                    dataSet[j + 1] = temp;
                }
            }
        }
        
        /// <summary>
        /// Улучшенная сортировка.
        /// </summary>
        /// <param name="dataSet"></param>
        /// <list type="T">Тип данных, из которых состоит коллекция.</list>
        [SortingMethod]
        public static void Advanced(ref List<double> dataSet)
        {
            var length = dataSet.Count();
            for (int i = 1; i < length; i++)
            {
                var sorted = true;
                for (int j = 0; j < length - i; j++)
                {
                    if (dataSet[j].CompareTo(dataSet[j + 1]) <= 0) 
                        continue;
                    
                    var temp = dataSet[j];
                    dataSet[j] = dataSet[j + 1];
                    dataSet[j + 1] = temp;
                    
                    sorted = false;
                }
                if (sorted) 
                    break;
            }
        } 
            
        /// <summary>
        /// Экспериментальная сортировка.
        /// </summary>
        /// <param name="dataSet"></param>
        /// <remarks>Данный метод не работает для вещественных чисел. Нужно либо
        /// учитывать точность, с которой нужно выполнять вычисления, либо вообще его не применять.</remarks>
        //[SortingMethod]
        public static void Experimental(ref List<double> dataSet)
        {
            var length = dataSet.Count();
            for (int i = 1; i < length; i++)
            {
                for (int j = 0; j < length - i; j++)
                {
                    var temp = (dataSet[j] + dataSet[j + 1] + Math.Abs(dataSet[j] - dataSet[j + 1])) / 2.0;
                    dataSet[j] = (dataSet[j] + dataSet[j + 1] - Math.Abs(dataSet[j] - dataSet[j + 1])) / 2.0;
                    dataSet[j + 1] = temp;
                }
            }
        } 
        
        #endregion
    }
}