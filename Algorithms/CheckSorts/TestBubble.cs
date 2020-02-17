using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;
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
        private const int Size = 10000;

        /// <summary>
        /// Количество прогонов сортировок.
        /// </summary>
        private const int NumberOfMeasurements = 10;

        /// <summary>
        /// Объект рандомайзера.
        /// </summary>
        private static readonly Random Rand = new Random();

        #endregion

        [Test]
        public void TestAll()
        {
            var unsortedList = new List<int>();
            for (var i = 0; i < Size; i++)
                unsortedList.Add(Rand.Next());

            var bubbleType = typeof(Bubble<int>);
            var methods = bubbleType.GetMethods(BindingFlags.Public | BindingFlags.Static);
            foreach (var method in methods)
            {
                if (method.GetCustomAttribute(typeof(SortingMethodAttribute)).Equals(null))
                    continue;
                if (method.GetParameters().Length != 1)
                    continue;
                
                DoTestingMeasurements(method, unsortedList, unsortedList.OrderBy(i => i).ToList());
            }
        }

        /// <summary>
        /// Протестировть метод на наборе случайных данных.
        /// </summary>
        /// <param name="method">Метод для прогона.</param>
        /// <param name="unsortedList">Неотсортированный список данных.</param>
        /// <param name="sortedList">Сортированный список данных.</param>
        private static void DoTestingMeasurements(MethodBase method, List<int> unsortedList,
            IReadOnlyCollection<int> sortedList)
        {
            if (!unsortedList.Any())
                Assert.Fail("Testing list is null.");

            var workingTime = new TimeSpan();
            var stopwatch = new Stopwatch();

            var testingResult = new TestingResult
            {
                Measurements = NumberOfMeasurements,
                TestName = $"{method.DeclaringType.Name}_{method.Name}",
                DataSetSize = Size,
                DataSetType = sortedList.GetType().Name,
                Beginning = DateTime.Now
            };

            for (var i = 0; i < NumberOfMeasurements; i++)
            {
                stopwatch.Start();
                unsortedList = method.Invoke(null, new object[] {unsortedList}) as List<int>;
                stopwatch.Stop();

                workingTime += stopwatch.Elapsed;
                if (!unsortedList.SequenceEqual(sortedList))
                    break;
            }

            testingResult.Ending = DateTime.Now;
            testingResult.Duration = testingResult.Ending - testingResult.Beginning;
            testingResult.AverageTime = workingTime / NumberOfMeasurements;
            var testingResultString = JToken.FromObject(testingResult).ToString();
            Console.WriteLine(testingResultString);
            Assert.Pass(testingResultString);
        }
    }

    /// <summary>
    /// Структура для записи результатов тестирования.
    /// </summary>
    [Serializable]
    public struct TestingResult
    {
        /// <summary>
        /// Время начала тестирования.
        /// </summary>
        public DateTime Beginning;

        /// <summary>
        /// Время окончания тестирования.
        /// </summary>
        public DateTime Ending;

        /// <summary>
        /// Продолжительность выполнения теста.
        /// </summary>
        public TimeSpan Duration;

        /// <summary>
        /// Количество проводимых измерений.
        /// </summary>
        public int Measurements;

        /// <summary>
        /// Имя теста.
        /// </summary>
        public string TestName;

        /// <summary>
        /// Среднее время, потраченное на прогон тестов.
        /// </summary>
        public TimeSpan AverageTime;

        /// <summary>
        /// Размер тестируемых данных.
        /// </summary>
        public int DataSetSize;

        /// <summary>
        /// Тип тестируемых данных.
        /// </summary>
        public string DataSetType;
    }
}