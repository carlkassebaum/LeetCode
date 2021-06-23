using System;

namespace MatrixBlockSum
{
    public class Solution
    {
        private enum Boundary { Top, Left, Bottom, Right };

        private int GetBoundarySum(int[][] mat, int i, int j, int K, Boundary boundary)
        {
            var startRow = 0;
            var startCol = 0;

            switch(boundary) {
                case Boundary.Top:
                    startRow = i - K - 1;
                    startCol = j - K;
                    break;
                case Boundary.Left:
                    startRow = i - K;
                    startCol = j - K - 1;
                    break;
                case Boundary.Bottom:
                    startRow = i + K + 1;
                    startCol = j - K;
                    break;
                case Boundary.Right:
                    startRow = i - K;
                    startCol = j + K + 1;
                    break;
            }

            var sum = 0;
            
            if (boundary == Boundary.Bottom || boundary == Boundary.Top)
            {
                if (startRow >= 0 && startRow < mat.Length)
                {
                    for (var local_j = Math.Max(startCol, 0); local_j < Math.Min(mat[0].Length, local_j + K); local_j++)
                    {
                        sum += mat[startRow][local_j];
                    }
                }
            }

            else if (boundary == Boundary.Left || boundary == Boundary.Right)
            {
                if (startCol >= 0 && startCol < mat[0].Length)
                {
                    for (var local_i = Math.Max(startCol, 0); local_i < Math.Min(mat.Length, local_i + K); local_i++)
                    {
                        sum += mat[local_i][startCol];
                    }
                }
            }

            return sum;
        }

        private int ComputeInitialSum(int[][] mat, int K)
        {
            var sum = 0;
            for (var i = 0; i <= K && i < mat.Length; i++)
            {
                for (var j = 0; j <= K && j < mat[0].Length; j++)
                {
                    sum += mat[i][j];
                }
            }
            return sum;
        }

        public int[][] MatrixBlockSum(int[][] mat, int K)
        {
            if (mat.Length == 0)
            {
                return new int[0][];
            }

            var m = mat.Length;
            var n = mat[0].Length;

            var answer = new int[m][];

            for (var i = 0; i < m; i++)
            {
                answer[i] = new int[n];
                for (var j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        answer[i][j] = ComputeInitialSum(mat, K);
                    }
                    else
                    {
                        Boundary lastComputedBoundary;
                        Boundary boundaryToCompute;
                        int lastComputedSum;

                        if (j == 0)
                        {
                            lastComputedBoundary = Boundary.Top;
                            boundaryToCompute = Boundary.Bottom;
                            lastComputedSum = answer[i - 1][j];
                        }
                        else
                        {
                            lastComputedBoundary = Boundary.Left;
                            boundaryToCompute = Boundary.Right;
                            lastComputedSum = answer[i][j - 1];
                        }

                        answer[i][j] = lastComputedSum + GetBoundarySum(mat, i, j, K, boundaryToCompute) - GetBoundarySum(mat, i, j, K, lastComputedBoundary);
                    }
                }
            }

            return answer;
        }
    }
}
