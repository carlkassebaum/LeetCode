using System;
using System.Collections.Generic;

namespace ShoppingOffers
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var price = new List<int> { 2, 5 };

            var special = new List<IList<int>>
            {
                new List<int> {3, 0, 5},
                new List<int> {1, 2, 10}
            };

            var needs = new List<int> { 3, 2 };

            //var price = new List<int> { 2, 3, 4 };

            //var special = new List<IList<int>>
            //{
            //    new List<int> {1, 1, 0, 4},
            //    new List<int> {2, 2, 1, 9}
            //};

            //var needs = new List<int> { 1, 2, 1 };

            var result = solution.ShoppingOffers(price, special, needs);

            Console.WriteLine(result);
        }
    }
}
