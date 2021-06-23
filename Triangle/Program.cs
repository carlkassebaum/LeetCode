using System;
using System.Collections.Generic;

namespace Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var triangle = new List<IList<int>>();
            //triangle.Add(new List<int> { 2 });
            //triangle.Add(new List<int> { 3, 4 });
            //triangle.Add(new List<int> { 6, 5, 7 });
            //triangle.Add(new List<int> { 4, 1, 3, 8 });

            triangle.Add(new List<int> { -10 });
            triangle.Add(new List<int> { -10, 1 });
            //triangle.Add(new List<int> { 3, 4 });
            //triangle.Add(new List<int> { 6, 5, 7 });
            //triangle.Add(new List<int> { 4, 1, 3, 8 });

            var solution = new Solution();

            var result = solution.MinimumTotal(triangle);

            Console.WriteLine(result);
        }
    }
}
