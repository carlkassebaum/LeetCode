using System;

namespace PerfectSquares
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var result = solution.NumSquares(26);

            Console.WriteLine(result);
        }
    }
}
