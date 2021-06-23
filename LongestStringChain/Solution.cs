using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestStringChain
{
    public class Solution
    {
        private LinkedList<int>[] GetWordLengthIndexLookup(string[] words)
        {
            var result = new LinkedList<int>[16];

            for (var i = 0; i < 16; i++)
            {
                result[i] = new LinkedList<int>();
            }

            for (var i = 0; i < words.Length; i++)
            {
                result[words[i].Length - 1].AddLast(i);
            }

            return result;
        }

        private bool IsPredecessor(string currentWord, string previousWord)
        {
            for (var i = 0; i < previousWord.Length; i++)
            {
                if(previousWord.Remove(i, 1) == currentWord)
                {
                    return true;
                }
            }
            return false;
        }

        public int LongestStrChain(string[] words)
        {
            var maximumSequence = 1;

            var wordLengthIndexLookup = GetWordLengthIndexLookup(words);

            var pastSequenceLengths = Enumerable.Repeat(1, wordLengthIndexLookup[15].Count).ToArray();

            for (var i = 14; i >= 0; i--)
            {
                var currentSequenceLengths = new int[wordLengthIndexLookup[i].Count];

                var j = 0;
                foreach (var currentIndex in wordLengthIndexLookup[i])
                {
                    var currentWord = words[currentIndex];
                    currentSequenceLengths[j] = 1;

                    var k = 0;
                    foreach(var previousIndex in wordLengthIndexLookup[i+1])
                    {
                        var previousWord = words[previousIndex];
                        if (IsPredecessor(currentWord, previousWord))
                        {
                            var newSequenceLength = pastSequenceLengths[k] + 1;
                            if (newSequenceLength > currentSequenceLengths[j])
                            {
                                currentSequenceLengths[j] = newSequenceLength;
                                if (newSequenceLength > maximumSequence)
                                {
                                    maximumSequence = newSequenceLength;
                                }
                            }
                        }
                        k++;
                    }
                    j++;
                }

                pastSequenceLengths = currentSequenceLengths;
            }

            return maximumSequence;
        }
    }
}
