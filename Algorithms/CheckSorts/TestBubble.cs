using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
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
    /// Имя файла для лога.
    /// </summary>
    private const string LogFilename = "Bubble.Test.log";
    
    /// <summary>
    /// Объект рандомайзера.
    /// </summary>
    private static readonly Random Rand = new Random();

    /// <summary>
    /// Стартовое сообщение при записи в лог.
    /// </summary>
    private const string StartMessage = "*********************";

    #endregion

    [Test]
    public void TestOnRandomDataset()
    {
      var unsorted = GetRandomizedDataSet();
      var test = new TestingResult();
      
      var bubbleType = typeof(Bubble);
      var methods = bubbleType.GetMethods(BindingFlags.Public | BindingFlags.Static);
      foreach (var method in methods)
      {
        if (!method.GetCustomAttributes(typeof(SortingMethodAttribute)).Any())
          continue;
        if (method.GetParameters().Length != 1)
          continue;

        test = DoTestingMeasurements(method, unsorted, unsorted.OrderBy(i => i).ToList());
        Console.WriteLine(test.ToString());
      }
      
      Assert.IsTrue(test.Success);
    }
    
    [Test]
    public void TestOnReverseDataset()
    {
      var unsorted = GetReversedDataSet();
      var test1 = new TestingResult();
      
      var bubbleType = typeof(Bubble);
      var methods = bubbleType.GetMethods(BindingFlags.Public | BindingFlags.Static);
      foreach (var method in methods)
      {
        if (!method.GetCustomAttributes(typeof(SortingMethodAttribute)).Any())
          continue;
        if (method.GetParameters().Length != 1)
          continue;

        test1 = DoTestingMeasurements(method, unsorted, unsorted.OrderBy(i => i).ToList());
        Console.WriteLine(test1.ToString());
      }
      
      Assert.IsTrue(test1.Success);
    }
    
    [Test]
    public void TestOnSortedDataset()
    {
      var unsorted = GetOrderedDataSet();
      var test1 = new TestingResult();
      
      var bubbleType = typeof(Bubble);
      var methods = bubbleType.GetMethods(BindingFlags.Public | BindingFlags.Static);
      foreach (var method in methods)
      {
        if (!method.GetCustomAttributes(typeof(SortingMethodAttribute)).Any())
          continue;
        if (method.GetParameters().Length != 1)
          continue;

        test1 = DoTestingMeasurements(method, unsorted, unsorted.OrderBy(i => i).ToList());
        Console.WriteLine(test1.ToString());
      }
      
      Assert.IsTrue(test1.Success);
    }
    
    #region Вспомогательные методы

    /// <summary>
    /// Получить случайные данные.
    /// </summary>
    /// <returns>Список случайных данных.</returns>
    private static List<double> GetRandomizedDataSet()
    {
      var unsorted = new List<double>();
      for (var i = 0; i < Size; i++)
        unsorted.Add( Rand.NextDouble());
      return unsorted;
    }

    /// <summary>
    /// Протестировть метод на наборе случайных данных.
    /// </summary>
    /// <param name="method">Метод для прогона.</param>
    /// <param name="unsorted">Неотсортированный список данных.</param>
    /// <param name="sortedList">Сортированный список данных.</param>
    private static TestingResult DoTestingMeasurements(MethodBase method, List<double> unsorted, IReadOnlyCollection<double> 
    sortedList)
    {
      if (!unsorted.Any() || (method == null))
        return new TestingResult()
        {
          Success = false
        };
      
      var workingTime = new TimeSpan();
      var stopwatch = new Stopwatch();

      var testingResult = new TestingResult
      {
        Measurements = NumberOfMeasurements,
        TestName = $"{method.DeclaringType.Name}_{method.Name}",
        DataSetSize = Size,
        Beginning = DateTime.Now
      };

      var needCheck = true;
      int i = 0;

      while (i++ < NumberOfMeasurements)
      {
        var tempUnsorted = unsorted;
        stopwatch.Start();
        method.Invoke(null, new object[] { tempUnsorted });
        stopwatch.Stop();
        workingTime += stopwatch.Elapsed;

        if (!needCheck) 
          continue;
        
        if (!tempUnsorted.SequenceEqual(sortedList))
        {
          testingResult.Success = false;
          break;
        }

        testingResult.Success = true;
        needCheck = false;
      } 
      
      testingResult.Ending = DateTime.Now;
      testingResult.Duration = testingResult.Ending - testingResult.Beginning;
      testingResult.AverageTime = workingTime / NumberOfMeasurements;

      using var writer = new StreamWriter(LogFilename, true);
      writer.WriteLine(StartMessage);
      writer.WriteLine(testingResult.ToString());
      
      return testingResult;
    }
    
    /// <summary>
    /// Получить набор данных, отсортированных по убыванию.
    /// </summary>
    /// <returns>Обратный список данных.</returns>
    private static List<double> GetReversedDataSet()
    {
      return GetRandomizedDataSet().OrderByDescending(d => d ).ToList();
    }
    
    /// <summary>
    /// Получить набор данных, отсортированных по возрастанию.
    /// </summary>
    /// <returns>Отсортированный список данных.</returns>
    private static List<double> GetOrderedDataSet()
    {
      return GetRandomizedDataSet().OrderBy(d => d ).ToList();
    }
    
    #endregion
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
    /// Успешность выполнения.
    /// </summary>
    public bool Success;

    public override string ToString()
    {
      return JToken.FromObject(this).ToString(Formatting.Indented);
    }
  }
}