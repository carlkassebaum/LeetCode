namespace SpiralMatrixII
{
    public class Solution
    {
        public enum directions {left, right, up, down};

        public int[,] GenerateMatrix(int n)
        {
            var result = new int[n, n];

            var count = 1;

            var leftBound = 0;
            var rightBound = n - 1;
            var topBound = 0;
            var bottomBound = n - 1;

            var direction = directions.right;

            var row = 0;
            var col = 0;

            while (count <= n * n)
            {
                result[row, col] = count;
                count++;

                if (direction == directions.right)
                {
                    if (col + 1 > rightBound)
                    {
                        topBound += 1;
                        row++;
                        direction = directions.down;
                    }
                    else
                    {
                        col++;
                    }
                }

                else if (direction == directions.down)
                {
                    if (row + 1 > bottomBound)
                    {
                        rightBound -= 1;
                        col--;
                        direction = directions.left;
                    }
                    else
                    {
                        row++;
                    }
                }

                else if (direction == directions.left)
                {
                    if (col - 1 < leftBound)
                    {
                        bottomBound -= 1;
                        row--;
                        direction = directions.up;
                    }
                    else
                    {
                        col--;
                    }
                }

                else if (direction == directions.up)
                {
                    if (row - 1 < topBound)
                    {
                        leftBound += 1;
                        col++;
                        direction = directions.right;
                    }
                    else
                    {
                        row--;
                    }
                }
            }

            return result;
        }
    }
}
