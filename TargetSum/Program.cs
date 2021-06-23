using System;

namespace TargetSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1 };

            var target = 1;

            var solution = new Solution();

            Console.WriteLine(solution.FindTargetSumWays(nums, target));
        }
    }
}
