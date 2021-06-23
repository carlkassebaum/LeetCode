namespace ArithmeticSlices
{
    public class Solution
    {
        public int NumberOfArithmeticSlices(int[] nums)
        {
            if (nums.Length < 3)
            {
                return 0;
            }
            var numArithmeticSlices = 0;

            var currentDelta = nums[1] - nums[0];
            var accumulator = 1;

            for (var i = 1; i < nums.Length - 1; i++)
            {
                var newDelta = nums[i + 1] - nums[i];
                if (newDelta != currentDelta)
                {
                    currentDelta = newDelta;
                    accumulator = 1;
                }
                else
                {
                    numArithmeticSlices += accumulator;
                    accumulator += 1;
                }
            }

            return numArithmeticSlices;
        }
    }
}
