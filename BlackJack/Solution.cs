using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Solution
    {
        public int BlackJack(int a, int b)
        {
            if (a < 0)
            {
                throw new ArgumentException($"a must be greater than 0: received value {a}");
            }
            if (b < 0)
            {
                throw new ArgumentException($"b must be greater than 0: received value {b}");
            }

            if (a <= 21 || b <= 21)
            {
                var aDist = 21 - a;
                var bDist = 21 - b;

                if (aDist >= 0 && bDist >= 0)
                {
                    return Math.Max(a, b);
                }
                else if (aDist < 0)
                {
                    return b;
                }
                else
                {
                    return a;
                }
            }

            return 0;
        }
    }
}
