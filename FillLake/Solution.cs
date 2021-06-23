using System;

namespace FillLake
{
    public class Solution
    {
        public int LakeVolume(int[] heights)
        {
            var totalVolume = 0;

            var localVolume = 0;
            var boundaryMax = 0;

            Action<int> updateVolumesSingleDirection = (index) =>
            {
                if (heights[index] >= boundaryMax)
                {
                    totalVolume += localVolume;
                    boundaryMax = heights[index];
                    localVolume = 0;
                }

                else
                {
                    localVolume += (boundaryMax - heights[index]);
                }
            };

            for (var i = 0; i < heights.Length; i++)
            {
                updateVolumesSingleDirection(i);
            }
            localVolume = 0;
            boundaryMax = 0;

            for (var i = heights.Length - 1; i >= 0; i--)
            {
                updateVolumesSingleDirection(i);
            }

            return totalVolume;
        }

    }
}
