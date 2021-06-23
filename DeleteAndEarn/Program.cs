using System;

namespace DeleteAndEarn
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var nums = new int[] { 2, 2, 3, 3, 3, 4 };

            var result = solution.DeleteAndEarn(nums);

            Console.WriteLine(result);
        }
    }
}
