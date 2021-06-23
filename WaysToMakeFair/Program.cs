using System;

namespace WaysToMakeFair
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var nums = new int[] { 1, 1, 1 };

            var result = solution.WaysToMakeFair(nums);

            Console.WriteLine(result);
        }
    }
}
