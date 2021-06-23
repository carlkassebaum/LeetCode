using System;
using System.Collections.Generic;
using System.Text;

namespace CollapseDuplicates
{
    class Solution
    {
        public string CollapseDuplicates(string a)
        {
            int i = 0;
            string result = "";
            while (i < a.Length)
            {
                char ch = a[i];
                result += ch;
                i++;
                while (i < a.Length && a[i] == ch)
                {
                    i++;
                }
            }
            return result;
        }
    }
}
