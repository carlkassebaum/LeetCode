using System;
using System.Collections.Generic;
using System.Text;

namespace Encoder
{
    public class Solution
    {
        public string[] Encoder(string[] raw, string[] codeWords)
        {
            var result = new string[raw.Length];
            var currentResultIndex = 0;

            var codeWordsIndex = 0;

            var encodings = new Dictionary<string, string>();

            foreach (var word in raw)
            {
                if (!encodings.ContainsKey(word))
                {
                    if (codeWordsIndex > codeWords.Length)
                    {
                        throw new ArgumentException("Could not assign all words in raw a code word. There must be more codeWords than unique words in raw.");
                    }

                    encodings[word] = codeWords[codeWordsIndex];
                    codeWordsIndex++;
                }

                result[currentResultIndex] = encodings[word];
                currentResultIndex++;
            }

            return result;
        }
    }
}
