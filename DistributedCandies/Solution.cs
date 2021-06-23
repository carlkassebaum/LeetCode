using System;
using System.Collections.Generic;
using System.Text;

namespace DistributedCandies
{
    public class Solution
    {
        public int DistributeCandies(int[] candyType)
        {
            var takenCandies = new HashSet<int>();

            var maxCandies = candyType.Length / 2;

            for (int i = 0; i < candyType.Length; i++)
            {
                if (!takenCandies.Contains(candyType[i]))
                {
                    takenCandies.Add(candyType[i]);
                    if (takenCandies.Count == maxCandies)
                    {
                        return maxCandies;
                    }
                }
            }

            return takenCandies.Count;
        }
    }
}
