using System;
using System.Collections.Generic;
using System.Text;

namespace Triangle
{
    public class Solution
    {
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            var triangleCount = triangle.Count;

            var minimumDistances = new List<int>(triangle[triangleCount - 1]);

            for (var i = triangleCount - 2; i >= 0; i--)
            {
                for (var j = 0; j < i + 1; j++)
                {
                    minimumDistances[j] = triangle[i][j] + Math.Min(minimumDistances[j], minimumDistances[j + 1]);
                }
            }

            return minimumDistances[0];
        }
    }
}
