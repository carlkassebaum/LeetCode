using System;

namespace ArithmeticSlices
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var nums = new int[]
            {
                1,
                2,
                3,
                4
            };

            Console.WriteLine(solution.NumberOfArithmeticSlices(nums));
        }
    }
}
