using System;

namespace Decompressor
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            var decompressed = solution.Decompress("10[3[a]abc2[2[d]]]");
            Console.WriteLine(decompressed);
        }
    }
}
