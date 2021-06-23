using System;

namespace Encoder
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var result = solution.Encoder(new string[] { "a", "b", "a" }, new string[] { "1", "2", "3", "4" });

            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
        }
    }
}
