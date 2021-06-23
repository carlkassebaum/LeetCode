using System;
using System.Collections.Generic;
using System.Text;

namespace MakeBricks
{
    public class Solution
    {
        public bool MakeBricks(int small, int big, int goal)
        {
            var distanceAcheivableWithBig = Math.Min(goal / 5, big) * 5;

            if ((distanceAcheivableWithBig + small) >= goal)
            {
                return true;
            }

            return false;
        }
    }
}
