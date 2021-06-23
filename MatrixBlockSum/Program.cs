using System;

namespace MatrixBlockSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var mat = new int[][] {
                new int[] {1, 2, 3 },
                new int[] {4, 5, 6 },
                new int[] {7, 8, 9}
            };

            var K = 1;

            var answer = solution.MatrixBlockSum(mat, K);
            for(var i = 0; i < answer.Length; i++)
            {
                for (var j = 0; j < answer[0].Length; j++)
                {
                    Console.Write($"{answer[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
