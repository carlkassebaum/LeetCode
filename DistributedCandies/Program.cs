using System;

namespace DistributedCandies
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var candies = new int[] { 6, 6, 6, 6 };

            Console.WriteLine(solution.DistributeCandies(candies));
        }
    }
}
