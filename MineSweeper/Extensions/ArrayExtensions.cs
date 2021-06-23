using System;
using System.Collections.Generic;
using System.Text;

namespace MineSweeper.Extensions
{
    public static class ArrayExtensions
    {
        public static void ForEachWithIndex<T>(this T[,] array, Action<T, int, int> handler)
        {
            int numRows = array.GetLength(0);
            int numColumns = array.GetLength(1);

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numColumns; j++)
                {
                    handler(array[i, j], i, j);
                }
            }
        }
    }
}
