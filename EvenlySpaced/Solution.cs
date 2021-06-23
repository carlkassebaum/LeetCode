using System;
using System.Collections.Generic;
using System.Text;

namespace EvenlySpaced
{
    public class Solution
    {
        private (int, int, int) GetSmallMediumLarge(int a, int b, int c)
        {
            if (b < a)
            {
                var temp = b;
                b = a;
                a = temp;
            }

            if (c < b)
            {
                var temp = c;
                c = b;
                b = temp;
            }

            if (b < a)
            {
                var temp = b;
                b = a;
                a = temp;
            }

            return (a, b, c);
        }

        public bool EvenlySpaced(int a, int b, int c)
        {
            var (small, medium, large) = GetSmallMediumLarge(a, b, c);

            if (medium - small == large - medium)
            {
                return true;
            }

            return false;
        }
    }
}
