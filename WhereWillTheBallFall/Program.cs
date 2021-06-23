using System;

namespace WhereWillTheBallFall
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var grid = new int[][]
            {
                new int[] { 1, 1, 1 },
                new int[] { -1, -1, -1},
                new int[] { -1, 1, 1},
            };

            var result = solution.FindBall(grid);

            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[0].Length; j++)
                {
                    Console.Write($"{grid[i][j]}\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("-----------------------------------");

            for (var i = 0; i < result.Length; i++)
            {
                Console.Write($"{result[i]}\t");
            }
            Console.WriteLine();
        }
    }
}
