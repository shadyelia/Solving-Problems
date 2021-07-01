using System;
using System.Collections.Generic;

namespace Robot_in_a_Grid
{
    class Program
    {
        class Point
        {
            public int Row { get; set; }
            public int Col { get; set; }
        }

        static void Main(string[] args)
        {
            bool[][] grid = { };
            Console.WriteLine("Path from origin to the end : ");
            List<Point> path = FindAPath(grid);
            
        }

        static List<Point> FindAPath(bool[][] grid)
        {
            if (grid == null || grid.Length == 0) return null;
            List<Point> path = new List<Point>();


            return path;

        }
    }
}
