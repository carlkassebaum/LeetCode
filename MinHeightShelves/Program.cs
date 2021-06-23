using System;

namespace MinHeightShelves
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var shelves = new int[][]{
                //new int[] {1, 1},
                //new int[] {2, 3},
                //new int[] {2, 3},
                //new int[] {1, 4}

                new int[] {1, 1},
                new int[] {2, 3},
                new int[] {2, 3},
                new int[] {1, 1},
                new int[] {1, 1},
                new int[] {1, 1},
                new int[] {1, 2}


            };

            //[[1,1],[2,3],[2,3],[1,1],[1,1],[1,1],[1,2]]

            Console.WriteLine(solution.MinHeightShelves(shelves, 4));
        }
    }
}
