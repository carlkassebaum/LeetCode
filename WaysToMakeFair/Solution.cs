namespace WaysToMakeFair
{
    public class Solution
    {
        private (int, int) GetOddEvenSums(int[] nums)
        {
            var oddSum = 0;
            var evenSum = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                {
                    oddSum += nums[i];
                }
                else
                {
                    evenSum += nums[i];
                }
            }

            return (oddSum, evenSum);
        }

        public int WaysToMakeFair(int[] nums)
        {
            var possibilities = 0;

            var (oddSum, evenSum) = GetOddEvenSums(nums);
            var oddPrior = 0;
            var evenPrior = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                var current = nums[i];
                var currentOdd = evenSum - evenPrior + oddPrior;
                var currentEven = oddSum - oddPrior + evenPrior;

                if (i % 2 == 0)
                {
                    currentEven -= current;
                    oddPrior += current;
                }
                else
                {
                    currentOdd -= current;
                    evenPrior += current;
                }

                if (currentOdd == currentEven)
                {
                    possibilities++;
                }
            }

            return possibilities;
        }
    }
}
