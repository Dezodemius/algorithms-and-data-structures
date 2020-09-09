using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
  internal class Program
  {
    private static Stack<int> visitedVertices = new Stack<int>();

    private static int[,] adjacencyMatrix;
    
    public static void Main(string[] args)
    {
      adjacencyMatrix = GetAdjacencyMatrix();
      DFS();
      Console.ReadKey();
    }

    private static int[,] GetAdjacencyMatrix()
    {
      return new int[8, 8]
      {
        {0, 1, 1, 1, 0, 0, 0, 0},
        {1, 0, 0, 1, 0, 0, 0, 0},
        {1, 0, 0, 0, 1, 0, 0, 0},
        {1, 1, 0, 0, 0, 1, 1, 0},
        {0, 0, 1, 0, 0, 0, 0, 1},
        {0, 0, 0, 1, 0, 0, 1, 0},
        {0, 0, 0, 1, 0, 1, 0, 0},
        {0, 0, 0, 0, 1, 0, 0, 0}
      };
    }

    private static void DFS()
    {
      var nodes = new int[8];
      for (var i = 0; i < 8; i++)
        nodes[i] = 0;
      visitedVertices.Push(0);
      while (visitedVertices.Any())
      {
        var node = visitedVertices.Peek();
        visitedVertices.Pop();
        if (nodes[node] == 2) continue;
        nodes[node] = 2;
        for (var j = 7; j >= 0; j--)
        {
          if (adjacencyMatrix[node, j] == 1 && nodes[j] != 2)
          {
            visitedVertices.Push(j);
            nodes[j] = 1;
          }
        }

        Console.WriteLine(node + 1);
      }
    }
  }
}