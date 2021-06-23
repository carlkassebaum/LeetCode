using System;

namespace MakeBricks
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var result = solution.MakeBricks(4, 2, 9);

            Console.WriteLine(result);
        }
    }
}
