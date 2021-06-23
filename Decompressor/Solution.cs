using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Decompressor
{ 
    public class Solution
    {
        private int GetLastDigitIndex(int startIndex, string compressedString)
        {
            var index = startIndex;
            while (index < compressedString.Length && char.IsDigit(compressedString[index]))
            {
                index++;
            }

            return index - 1;
        }


        public string Decompress(string compressedString)
        {
            var (decompressedString, _) = Decompress(compressedString, 0);
            return decompressedString;
        }

        private int ParseDigit(string compressedString, int startIndex, int endIndex)
        {
            return int.Parse(compressedString.Substring(startIndex, endIndex - startIndex + 1));
        }

        private (string, int) Decompress(string compressedString, int lowerBound)
        {
            var lastDigitIndex = GetLastDigitIndex(lowerBound, compressedString);
            Debug.Assert(lastDigitIndex != lowerBound - 1);

            var repetitions = ParseDigit(compressedString, lowerBound, lastDigitIndex);
            var openSquareBracketIndex = lastDigitIndex + 1;

            Debug.Assert(openSquareBracketIndex < compressedString.Length && compressedString[openSquareBracketIndex] == '[');
            var startInnerStringIndex = openSquareBracketIndex + 1;
            Debug.Assert(startInnerStringIndex < compressedString.Length && compressedString[startInnerStringIndex] != ']');

            var endInnerStringIndex = -1;

            for (int i = startInnerStringIndex; i < compressedString.Length; i++)
            {
                if (char.IsDigit(compressedString[i]))
                {
                    var (innerDecompressed, innerEndIndex) = Decompress(compressedString, i);
                    var endDecompressedStringIndex = innerEndIndex + 1;

                    Debug.Assert(endDecompressedStringIndex < compressedString.Length);

                    var previousDecompressedResult = compressedString.Substring(0, i);
                    var endCompressedString = compressedString.Substring(endDecompressedStringIndex, compressedString.Length - endDecompressedStringIndex);

                    compressedString = string.Concat(
                        previousDecompressedResult,
                        innerDecompressed,
                        endCompressedString
                    );

                    i = previousDecompressedResult.Length + innerDecompressed.Length;

                    Debug.Assert(i < compressedString.Length);
                }

                if (compressedString[i] == ']') {
                    endInnerStringIndex = i;
                    break;
                }
            }

            Debug.Assert(endInnerStringIndex != -1);

            var innerString = compressedString.Substring(startInnerStringIndex, endInnerStringIndex - startInnerStringIndex);
            var decompressed = string.Concat(Enumerable.Repeat(innerString, repetitions));

            return (decompressed, endInnerStringIndex);
        }
    }
}
