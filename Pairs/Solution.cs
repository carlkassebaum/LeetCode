using System;
using System.Collections.Generic;
using System.Text;

namespace Pairs
{
    public class Solution
    {
        public IDictionary<char, char> Pairs(string[] strings)
        {
            var result = new Dictionary<char, char>();

            foreach (var str in strings)
            {
                if (str.Length > 0)
                {
                    var first = str[0];
                    var last = str[str.Length - 1];

                    result[first] = last;
                }
            }

            return result;
        }
    }
}
