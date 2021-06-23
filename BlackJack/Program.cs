using System;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var result = solution.BlackJack(22, 22);

            Console.WriteLine(result);
        }
    }
}
