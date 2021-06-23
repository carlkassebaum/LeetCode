using System;

namespace MineSweeper.Extensions
{
    public static class IListExtensions
    {
        public static void Shuffle2D<T>(this T[,] list, int? seed=null)
        {
            var rng = seed == null ? new Random() : new Random((int)seed);

            var numRows = list.GetLength(0);
            var numColumns = list.GetLength(1);

            var n = list.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);

                var currentRow = n / numRows;
                var currentColumn = n % numColumns;

                var newRow = k / numRows;
                var newColumn = k % numColumns;

                T value = list[newRow, newColumn];
                list[newRow, newColumn] = list[currentRow, currentColumn];
                list[currentRow, currentColumn] = value;
            }
        }
    }
}
