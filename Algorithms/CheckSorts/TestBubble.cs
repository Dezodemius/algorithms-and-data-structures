using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using Sorts;

namespace CheckSorts
{
    public class TestBubble
    {
        #region Поля
        
        /// <summary>
        /// Размер тестируемого набора данных.
        /// </summary>
        private const int Size = 1000;
        
        /// <summary>
        /// Количество прогонов сортировок.
        /// </summary>
        private const int NumberOfMeasurements = 100;
        
        /// <summary>
        /// Объект рандомайзера.
        /// </summary>
        private static readonly Random Rand = new Random();

        #endregion

        #region Тесты

        #region Простой пузырёк.

         [Test]
        public void TestSimple()
        {
            var stopwatch = new Stopwatch();
            var list = new List<int>();
            var sortingTime = new TimeSpan();

            for (var i = 0; i < NumberOfMeasurements; i++)
            {
                list = new List<int>();
                for (var j = 0; j < Size; j++)
                    list.Add(Rand.Next());
                
                stopwatch.Start();
                Bubble<int>.Simple(ref list);
                stopwatch.Stop();
                
                sortingTime += stopwatch.Elapsed;
            }
            
            var sortedList = list.OrderBy(i => i);
            Console.WriteLine($"Обыкновенная сортировка пузырьком: {sortingTime / NumberOfMeasurements}");
            Assert.IsTrue(sortedList.SequenceEqual(list));
        }
        
        [Test]
        public void TestSimpleOnReverseList()
        {
            var stopwatch = new Stopwatch();
            var list = new List<int>();
            var sortingTime = new TimeSpan();

            for (var i = 0; i < NumberOfMeasurements; i++)
            {
                list = new List<int>();
                for (var j = 0; j < Size; j++)
                    list.Add(Rand.Next());
                
                list = list.OrderByDescending(e => e).ToList();
                
                stopwatch.Start();
                Bubble<int>.Simple(ref list);
                stopwatch.Stop();
                sortingTime += stopwatch.Elapsed;
            }
            
            var sortedList = list.OrderBy(i => i);
            Console.WriteLine($"Обыкновенная сортировка пузырьком: {sortingTime / NumberOfMeasurements}");
            Assert.IsTrue(sortedList.SequenceEqual(list));
        }
        
        [Test]
        public void TestSimpleOnSortedList()
        {
            var stopwatch = new Stopwatch();
            var list = new List<int>();
            var sortingTime = new TimeSpan();

            for (var i = 0; i < NumberOfMeasurements; i++)
            {
                list = new List<int>();
                for (var j = 0; j < Size; j++)
                    list.Add(Rand.Next());
                
                list = list.OrderBy(e => e).ToList();
                
                stopwatch.Start();
                Bubble<int>.Simple(ref list);
                stopwatch.Stop();
                sortingTime += stopwatch.Elapsed;
            }
            
            var sortedList = list.OrderBy(i => i);
            Console.WriteLine($"Обыкновенная сортировка пузырьком: {sortingTime / NumberOfMeasurements}");
            Assert.IsTrue(sortedList.SequenceEqual(list));
        }

        #endregion

        #region Улучшенный пузырёк.
        
        [Test]
        public void TestAdvanced()
        {
            var stopwatch = new Stopwatch();
            var list = new List<int>();
            
            for (var i = 0; i < Size; i++)
                list.Add(Rand.Next());
            
            stopwatch.Start();
            var sortedList = list.OrderBy(i => i);
            stopwatch.Stop();
            Console.WriteLine($"Встроенная сортировка: {stopwatch.Elapsed}");
            
            stopwatch.Start();
            Bubble<int>.Advanced(ref list);
            stopwatch.Stop();
            Console.WriteLine($"Улучшенная сортировка пузырьком: {stopwatch.Elapsed}");
            
            Assert.IsTrue(sortedList.SequenceEqual(list));
        }
        
        [Test]
        public void TestAdvancedOnReverseList()
        {
            var stopwatch = new Stopwatch();
            var list = new List<int>();
            
            for (var i = 0; i < Size; i++)
                list.Add(Rand.Next());
            
            list = list.OrderByDescending(a => a).ToList();
            
            stopwatch.Start();
            var sortedList = list.OrderBy(i => i);
            stopwatch.Stop();
            Console.WriteLine($"Встроенная сортировка: {stopwatch.Elapsed}");
            
            stopwatch.Start();
            Bubble<int>.Advanced(ref list);
            stopwatch.Stop();
            Console.WriteLine($"Улучшенная сортировка пузырьком: {stopwatch.Elapsed}");
            
            Assert.IsTrue(sortedList.SequenceEqual(list));
        }
        
        [Test]
        public void TestAdvancedOnSortedList()
        {
            var stopwatch = new Stopwatch();
            var list = new List<int>();
            
            for (var i = 0; i < Size; i++)
                list.Add(Rand.Next());
            
            list = list.OrderBy(i => i).ToList();
            
            stopwatch.Start();
            var sortedList = list.OrderBy(i => i);
            stopwatch.Stop();
            Console.WriteLine($"Встроенная сортировка: {stopwatch.Elapsed}");
            
            stopwatch.Start();
            Bubble<int>.Advanced(ref list);
            stopwatch.Stop();
            Console.WriteLine($"Улучшенная сортировка пузырьком: {stopwatch.Elapsed}");
            
            Assert.IsTrue(sortedList.SequenceEqual(list));
        }

        #endregion

        #region Экспериментальный пузырёк.

        [Test]
        public void TestExperimental()
        {
            var stopwatch = new Stopwatch();
            var list = new List<double>();
            
            for (var i = 0; i < Size; i++)
                list.Add(Rand.NextDouble());
            
            stopwatch.Start();
            var sortedList = list.OrderBy(i => i);
            stopwatch.Stop();
            Console.WriteLine($"Встроенная сортировка: {stopwatch.Elapsed}");
            
            stopwatch.Start();
            Bubble<int>.Experimental(ref list);
            stopwatch.Stop();
            Console.WriteLine($"Эксперименталньая сортировка пузырьком: {stopwatch.Elapsed}");
            
            Assert.IsTrue(sortedList.SequenceEqual(list));
        }
        
        [Test]
        public void TestExperimentalOnReverseList()
        {
            var stopwatch = new Stopwatch();
            var list = new List<double>();
            
            for (var i = 0; i < Size; i++)
                list.Add(Rand.NextDouble());
            
            list = list.OrderByDescending(a => a).ToList();
            stopwatch.Start();
            var sortedList = list.OrderBy(i => i);
            stopwatch.Stop();
            Console.WriteLine($"Встроенная сортировка: {stopwatch.Elapsed}");
            
            stopwatch.Start();
            Bubble<int>.Experimental(ref list);
            stopwatch.Stop();
            Console.WriteLine($"Эксперименталньая сортировка пузырьком: {stopwatch.Elapsed}");
            
            Assert.IsTrue(sortedList.SequenceEqual(list));
        }
        
        [Test]
        public void TestExperimentalOnSortedList()
        {
            var stopwatch = new Stopwatch();
            var list = new List<double>();
            
            for (var i = 0; i < Size; i++)
                list.Add(Rand.NextDouble());
            
            list = list.OrderBy(a => a).ToList();
            
            stopwatch.Start();
            var sortedList = list.OrderBy(i => i);
            stopwatch.Stop();
            Console.WriteLine($"Встроенная сортировка: {stopwatch.Elapsed}");
            
            stopwatch.Start();
            Bubble<int>.Experimental(ref list);
            stopwatch.Stop();
            Console.WriteLine($"Эксперименталньая сортировка пузырьком: {stopwatch.Elapsed}");
            
            Assert.IsTrue(sortedList.SequenceEqual(list));
        }
        
        #endregion
        
        #endregion
    }
}