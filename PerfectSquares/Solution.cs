using System.Collections.Generic;

namespace PerfectSquares
{
    public class Solution
    {
        public int NumSquares(int n, Dictionary<int, int> memory)
        {
            if (memory.ContainsKey(n))
            {
                return memory[n];
            }

            var i = 1;
            var square = 1;

            var min = n;

            while (square <= n)
            {
                if (n == square)
                {
                    memory[n] = 1;
                    return 1;
                }
                var remainderMin = NumSquares(n - square, memory);
                if (remainderMin + 1 < min)
                {
                    min = remainderMin + 1;
                }
                i += 1;
                square = i * i;
            }

            memory[n] = min;
            return min;
        }

        public int NumSquares(int n)
        {
            var memory = new Dictionary<int, int>();
            return NumSquares(n, memory);
        }
    }
}
