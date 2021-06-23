using System;

namespace FillLake
{
    public class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var heights = new int[] { 1, 3, 2, 4, 1, 3, 1, 4, 5, 2, 2, 1, 4, 2, 2 };

            Console.WriteLine(solution.LakeVolume(heights));
        }
    }
}
