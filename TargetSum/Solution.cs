using System;
using System.Collections.Generic;

namespace TargetSum
{
    public class Solution
    {
        public int FindTargetSumWays(int[] nums, int S)
        {
            var priorSums = new Dictionary<int, int>();
            
            if (nums[0] == -nums[0])
            {
                priorSums[nums[0]] = 2;
            }
            else
            {
                priorSums[nums[0]] = 1;
                priorSums[-nums[0]] = 1;
            }

            var currentSums = new Dictionary<int, int>();

            for (var i = 1; i < nums.Length; i++)
            {
                foreach (var previousSum in priorSums.Keys)
                {
                    var newPositiveSum = previousSum + nums[i];
                    var newNegativeSum = previousSum - nums[i];

                    if (currentSums.ContainsKey(newPositiveSum))
                    {
                        currentSums[newPositiveSum] += priorSums[previousSum];
                    }
                    else
                    {
                        currentSums[newPositiveSum] = priorSums[previousSum];
                    }

                    if (currentSums.ContainsKey(newNegativeSum))
                    {
                        currentSums[newNegativeSum] += priorSums[previousSum];
                    }
                    else
                    {
                        currentSums[newNegativeSum] = priorSums[previousSum];
                    }
                }

                priorSums = currentSums;
                currentSums = new Dictionary<int, int>();
            }

            if (!priorSums.ContainsKey(S))
            {
                return 0;
            }

            return priorSums[S];
        }
    }
}
