using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorts
{
    /// <summary>
    /// Объект для работы с пузырьковой сортировкой.
    /// </summary>
    public static class Bubble<T>  where T : IComparable<T>
    {
        #region Методы.
        
        /// <summary>
        /// Обыкновенная сортировка.
        /// </summary>
        /// <param name="dataSet">Набор целочисленных данных.</param>
        public static void Simple(ref List<T> dataSet)
        {
            for (int i = 0; i < dataSet.Count(); i++)
            {
                for (int j = 0; j < dataSet.Count() - 1; j++)
                {
                    if (dataSet[j].CompareTo(dataSet[j + 1]) <= 0) continue;
                    
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
        public static void Advanced(ref List<T> dataSet)
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
                    return;
            }
        } 
            
        /// <summary>
        /// Экспериментальная сортировка.
        /// </summary>
        /// <param name="dataSet"></param>
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