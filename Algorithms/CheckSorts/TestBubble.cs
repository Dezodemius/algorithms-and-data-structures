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

        private const int Size = 1000;
        
        private static readonly Random Rand = new Random();

        #endregion

        #region Тесты

        [Test]
        public void TestSimple()
        {
            var stopwatch = new Stopwatch();
            var list = new List<int>();
            
            for (int i = 0; i < Size; i++)
                list.Add(Rand.Next());
            
            stopwatch.Start();
            var sortedList = list.OrderBy(i => i);
            stopwatch.Stop();
            Console.WriteLine($"Встроенная сортировка: {stopwatch.Elapsed}");
            
            stopwatch.Start();
            Bubble<int>.Simple(ref list);
            stopwatch.Stop();
            Console.WriteLine($"Обыкновенная сортировка пузырьком: {stopwatch.Elapsed}");
            
            Assert.IsTrue(sortedList.SequenceEqual(list));
        }
        
        [Test]
        public void TestAdvanced()
        {
            var stopwatch = new Stopwatch();
            var list = new List<int>();
            
            for (int i = 0; i < Size; i++)
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
        public void TestExperimental()
        {
            var stopwatch = new Stopwatch();
            var list = new List<double>();
            
            for (int i = 0; i < Size; i++)
                list.Add(Rand.NextDouble());
            
            stopwatch.Start();
            var sortedList = list.OrderBy(i => i);
            stopwatch.Stop();
            Console.WriteLine($"Встроенная сортировка: {stopwatch.Elapsed}");
            
            stopwatch.Start();
            Bubble<int>.Experimental(ref list);
            stopwatch.Stop();
            Console.WriteLine($"Улучшенная сортировка пузырьком: {stopwatch.Elapsed}");
            
            Assert.IsTrue(sortedList.SequenceEqual(list));
        }
        
        #endregion
    }
}