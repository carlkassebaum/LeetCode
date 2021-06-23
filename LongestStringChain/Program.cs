using System;

namespace LongestStringChain
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            //var words = new string[] { "a", "b", "ba", "bca", "bda", "bdca" };

            //var words = new string[] { "xbc", "pcxbcf", "xb", "cxbc", "pcxbc" };

            var words = new string[] { "a", "b", "podiums", "podim", "ba", "bca", "bda", "pim", "bdca", "bedca", "fbedca", "pdim", "podium" };


            var result = solution.LongestStrChain(words);

            Console.WriteLine(result);
        }
    }
}
