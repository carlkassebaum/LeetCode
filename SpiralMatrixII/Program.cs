using System;

namespace SpiralMatrixII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var solution = new Solution();

            var n = 5;

            var result = solution.GenerateMatrix(n);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{result[i,j]} ");
                }
            }
        }
    }
}
