using System.Linq;

namespace WhereWillTheBallFall
{
    public class Solution
    {
        private int ProgressBall(int ballIndex, int[] row)
        {
            // Stuck against left wall
            if (ballIndex == 0 && row[ballIndex] == -1)
            {
                return -1;
            }

            // Stuck against right wall
            if (ballIndex == row.Length - 1 && row[ballIndex] == 1)
            {
                return -1;
            }

            // Ball moves left into 'v'
            if (ballIndex > 0 && row[ballIndex] == -1 && row[ballIndex - 1] == 1)
            {
                return -1;
            }

            // Ball moves right into 'v'
            if (ballIndex < row.Length - 1 && row[ballIndex] == 1 && row[ballIndex + 1] == -1)
            {
                return -1;
            }

            return ballIndex += row[ballIndex];
        }

        public int[] FindBall(int[][] grid)
        {
            var m = grid.Length;
            var n = grid[0].Length;

            var result = Enumerable.Range(0, n).ToArray();

            for (var row = 0; row < m; row++)
            {
                for (var ball = 0; ball < n; ball++)
                {
                    if (result[ball] != -1)
                    {
                        result[ball] = ProgressBall(result[ball], grid[row]);
                    }
                }
            }

            return result;
        }
    }
}
