using System;

namespace MineSweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            var mineMap = new MineMap(10, 10, 10);
            mineMap.DisplayMaskedMap();
            Console.WriteLine("--------------");
            mineMap.DisplayMineMap();
            Console.WriteLine("--------------");

            int rowClicked = 1;
            int columnClicked = 1;

            if(!mineMap.IsBomb(rowClicked, columnClicked))
            {
                mineMap.RevealSurrounds(rowClicked, rowClicked);
            }
            else
            {
                mineMap.UnmaskBombs();
            }

            mineMap.DisplayMaskedMap();
        }
    }
}
