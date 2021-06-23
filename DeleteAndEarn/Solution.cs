using System;
using System.Collections.Generic;
using System.Text;

namespace DeleteAndEarn
{
    public class Solution
    {
        public int DeleteAndEarn(int[] nums)
        {
            var maxPointsForNumber = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (!maxPointsForNumber.ContainsKey(nums[i]))
                {
                    maxPointsForNumber[nums[i]] = nums[i];
                }
                else
                {
                    maxPointsForNumber[nums[i]] += nums[i];
                }
            }

            var maxPoints = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                var pointsToGain = maxPointsForNumber[nums[i]];

                if (pointsToGain > 0)
                {
                    var pointsToLoose = 0;
                    var containsSmallerNumsPoints = maxPointsForNumber.ContainsKey(nums[i] - 1);
                    var containsLargerNumsPoints = maxPointsForNumber.ContainsKey(nums[i] + 1);

                    if (containsSmallerNumsPoints)
                    {
                        pointsToLoose += maxPointsForNumber[nums[i] - 1];
                    }
                    if (containsLargerNumsPoints)
                    {
                        pointsToLoose += maxPointsForNumber[nums[i] + 1];
                    }

                    if (pointsToGain > pointsToLoose)
                    {
                        maxPoints += pointsToGain;
                        maxPointsForNumber[nums[i]] = 0;

                        if (containsSmallerNumsPoints)
                        {
                            maxPointsForNumber[nums[i] - 1] = 0;
                        }
                        if (containsLargerNumsPoints)
                        {
                            maxPointsForNumber[nums[i] + 1] = 0;
                        }
                    }
                }
            }

            return maxPoints;
        }
    }
}
