using System;
using System.Linq;

namespace MinHeightShelves
{
    public class Solution
    {
        public int MinHeightShelves(int[][] books, int shelf_width)
        {
            var dp = Enumerable.Repeat(-1, books.Length).ToArray();

            dp[0] = books[0][1];

            var currentShelfWidth = shelf_width - books[0][0];
            var currentShelfHeight = books[0][1];

            var baseShelfHeight = 0;

            for (var i = 1; i < books.Length; i++)
            {
                var currentBookWidth = books[i][0];
                var currentBookHeight = books[i][1];

                if (currentBookWidth <= currentShelfWidth)
                {
                    currentShelfWidth -= currentBookWidth;
                    currentShelfHeight = Math.Max(currentShelfHeight, currentBookHeight);
                    dp[i] = baseShelfHeight + currentShelfHeight;
                }
                else
                {
                    dp[i] = dp[i - 1] + currentBookHeight;
                    baseShelfHeight = dp[i - 1];
                    currentShelfWidth = shelf_width - currentBookWidth;
                }

                var newShelfHeight = currentBookHeight;
                var newShelfWidth = shelf_width - currentBookWidth;

                var j = i - 1;
                while (j > 0 && newShelfWidth >= books[j][0])
                {
                    newShelfWidth -= books[j][0];
                    newShelfHeight = Math.Max(books[j][1], newShelfHeight);

                    var newMinHeight = dp[j - 1] + newShelfHeight;

                    if (newMinHeight < dp[i])
                    {
                        dp[i] = newMinHeight;
                        baseShelfHeight = dp[j - 1];
                        currentShelfWidth = newShelfWidth;
                        currentShelfHeight = newShelfHeight;
                    }
                    j--;
                }
            }

            return dp[books.Length - 1];
        }
    }
}
