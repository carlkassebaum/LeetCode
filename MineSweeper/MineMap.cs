using MineSweeper.Aspects;
using MineSweeper.Extensions;
using System;

namespace MineSweeper
{
    public class MineMap
    {
        private readonly int MineKey = 9;
        private readonly int EmptyKey = 0;
        private readonly char MaskKey = '*';
        private readonly char ExplodedMineKey = 'B';

        private readonly int numRows;

        private readonly int numColumns;

        private readonly int[,] mineMap;

        private readonly char[,] maskedMap; 

        public MineMap(int numRows, int numColumns, int numMines)
        {
            this.numRows = numRows;
            this.numColumns = numColumns;

            mineMap = new int[numRows, numColumns];
            maskedMap = new char[numRows, numColumns];
            SetMapMines(numMines);
            MaskMaskedMap();
        }
]
        public void UnmaskBombs()
        {
            mineMap.ForEachWithIndex((mapElement, i, j) =>
            {
                if (mapElement == MineKey)
                {
                    maskedMap[i, j] = ExplodedMineKey;
                }
            });
        }

        public void RevealSurrounds(int i, int j)
        {
            if (IsBomb(i, j))
            {
                throw new ArgumentException($"A Bomb was clicked!");
            }

            RevealCells(i, j);
        }

        public bool IsBomb(int i, int j)
        {
            return mineMap[i, j] == 9 ? true : false;
        }

        public void DisplayMineMap()
        {
            for (int i = 0; i < numRows; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < numColumns; j++)
                {
                    Console.Write($"{mineMap[i, j]} ");
                }
                Console.Write("|");
                Console.WriteLine();
            }
        }

        public void DisplayMaskedMap()
        {
            for (int i = 0; i < numRows; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < numColumns; j++)
                {
                    Console.Write($"{maskedMap[i, j]} ");
                }
                Console.Write("|");
                Console.WriteLine();
            }
        }

        private void MaskMaskedMap()
        {
            mineMap.ForEachWithIndex((_, i, j) => maskedMap[i, j] = MaskKey);
        }

        private void SetMineMapValue1D(int index, int value)
        {
            var currentRow = index / numRows;
            var currentColumn = index % numColumns;
            mineMap[currentRow, currentColumn] = value;
        }

        private void SetMapMines(int numMines)
        {
            for (var i = 0; i < numMines; i++)
            {
                SetMineMapValue1D(i, MineKey);
            }
            for (var i = numMines; i < mineMap.Length; i++)
            {
                SetMineMapValue1D(i, EmptyKey);
            }

            mineMap.Shuffle2D();
            SetMineDistances();
            MaskMaskedMap();
        }

        private void IncrementMineDistanceWithMineCheck(int i, int j)
        {
            if ((i >= 0 && i < numRows) && (j >= 0 && j < numColumns) && mineMap[i, j] != MineKey)
            {
                mineMap[i, j]++;
            }
        }

        private void SetMineDistances()
        {
            mineMap.ForEachWithIndex((mapElement, i, j) =>
            {
                if (mapElement == MineKey)
                {
                    IncrementMineDistanceWithMineCheck(i - 1, j - 1);
                    IncrementMineDistanceWithMineCheck(i - 1, j);
                    IncrementMineDistanceWithMineCheck(i - 1, j + 1);
                    IncrementMineDistanceWithMineCheck(i, j - 1);
                    IncrementMineDistanceWithMineCheck(i, j + 1);
                    IncrementMineDistanceWithMineCheck(i + 1, j - 1);
                    IncrementMineDistanceWithMineCheck(i + 1, j);
                    IncrementMineDistanceWithMineCheck(i + 1, j + 1);
                }
            });
        }

        private void RevealNeighbourIfRevealable(int i, int j)
        {
            if ((i >= 0 && i < numRows) && (j >= 0 && j < numColumns))
            {
                if (maskedMap[i, j] == '*')
                {
                    RevealCells(i, j);
                }
            }

        }

        private void RevealCells(int i, int j)
        {
            if (mineMap[i, j] == EmptyKey)
            {
                maskedMap[i, j] = ' ';
                RevealNeighbourIfRevealable(i - 1, j - 1);
                RevealNeighbourIfRevealable(i - 1, j);
                RevealNeighbourIfRevealable(i - 1, j + 1);
                RevealNeighbourIfRevealable(i, j - 1);
                RevealNeighbourIfRevealable(i, j + 1);
                RevealNeighbourIfRevealable(i + 1, j - 1);
                RevealNeighbourIfRevealable(i + 1, j);
                RevealNeighbourIfRevealable(i + 1, j + 1);
            }
            else if (mineMap[i, j] != MineKey)
            {
                maskedMap[i, j] = (char)(mineMap[i, j] + '0');
            }
        }
    }
}
