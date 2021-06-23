using System;

namespace VideoStitching
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();


            // [[0,2],[4,6],[8,10],[1,9],[1,5],[5,9]]
            // var T = 10;
            //var clips = new int[][]
            //{
            //    new int[] { 0, 2 },
            //    new int[] { 4, 6 },
            //    new int[] { 8, 10 },
            //    new int[] { 1, 9 },
            //    new int[] { 1, 5 },
            //    new int[] { 5, 9 }
            //};
            //var T = 10;

            //[],[],[],[],[],[],[],[],[],[],[],[],[],[],[],[]
            var clips = new int[][]
            {
                new int[] { 0,1 },
                new int[] { 6,8 },
                new int[] { 0,2 },
                new int[] { 5,6 },
                new int[] { 0,4 },
                new int[] { 0,3 },
                new int[] { 6,7 },
                new int[] { 1,3 },
                new int[] { 4,7 },
                new int[] { 1,4 },
                new int[] { 2,5 },
                new int[] { 2,6 },
                new int[] { 3,4 },
                new int[] { 4,5 },
                new int[] { 5,7 },
                new int[] { 6, 9 }
            };

            var T = 9;

            var result = solution.VideoStitching(clips, T);

            Console.WriteLine(result);
        }
    }
}
