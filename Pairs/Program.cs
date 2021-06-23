using System;

namespace Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var result = solution.Pairs(new string[] { "code", "bug" });

            foreach (var key in result.Keys)
            {
                Console.WriteLine($"{key}: {result[key]}");
            }

            Console.WriteLine("Hello World!");
        }
    }
}
