using System;

namespace Sorts
{
    /// <summary>
    /// Атрибут для различия алгоритмов сортировок.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SortingAlgorithmAttribute : System.Attribute
    {
    }
    
    /// <summary>
    /// Атрибут для различия методов алгоритмов сортировок
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class SortingMethodAttribute : System.Attribute
    {
    }
}