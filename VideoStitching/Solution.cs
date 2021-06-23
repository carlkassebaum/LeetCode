using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace VideoStitching
{

    public class Solution
    {
        class ClipComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                var x_start = ((int[])x)[0];
                var y_start = ((int[])y)[0];

                if (x_start == y_start)
                {
                    return 0;
                }

                return x_start < y_start ? -1 : 1;
            }
        }

        public int VideoStitching(int[][] clips, int T)
        {
            Array.Sort(clips, new ClipComparer());

            if (T == 0)
            {
                return 0;
            }

            if (clips[0][0] > 0)
            {
                return -1;
            }

            var minClipsToEnd = new int[T + 1];
            for (var i = 0; i <= T; i++)
            {
                minClipsToEnd[i] = -1;
            }

            minClipsToEnd[0] = 0;

            for (var i = 0; i < clips.Length; i++)
            {
                var clipStart = clips[i][0];
                var clipEnd = clips[i][1];

                if (clipStart <= T && minClipsToEnd[clipStart] == -1)
                {
                    return -1;
                }

                for (var j = clipStart; j <= clipEnd && j <= T; j++)
                {
                    if (minClipsToEnd[j] == -1)
                    {
                        minClipsToEnd[j] = minClipsToEnd[clipStart] + 1;
                    }
                    else
                    {
                        minClipsToEnd[j] = Math.Min(minClipsToEnd[clipStart] + 1, minClipsToEnd[j]);
                    }
                }
            }

            return minClipsToEnd[T];
        }
    }
}
