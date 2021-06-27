using System;

namespace CountSortedVowelStrings
{
    public class Solution
    {
        private const int NumVowelsInAlphabet = 5;

        private void InitialiseDp(int[] dp)
        {
            for (var i = 0; i < NumVowelsInAlphabet; i++)
            {
                dp[i] = 1;
            }
        }

        public int CountVowelStrings(int n)
        {
            if (n < 1)
            {
                throw new ArgumentException("n must be greater than or equal to 1.");
            }

            var dp = new int[NumVowelsInAlphabet];
            InitialiseDp(dp);

            for (var i = 1; i < n; i++)
            {
                var current = new int[NumVowelsInAlphabet];

                current[NumVowelsInAlphabet - 1] = dp[NumVowelsInAlphabet - 1];

                for (var j = NumVowelsInAlphabet - 2; j >= 0; j--)
                {
                    current[j] = dp[j] + current[j + 1];
                }

                dp = current;
            }

            var result = 0;

            for (var i = 0; i < NumVowelsInAlphabet; i++)
            {
                result += dp[i];
            }

            return result;
        }
    }
}
