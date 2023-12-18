using System;
using System.Collections.Generic;
using System.Text;

namespace mineText
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] map = {
            {"*", ".", ".", "."},
            {".", ".", ".", "."},
            {".", "*", ".", "."},
            {".", ".", ".", "."}
        };
            int HEIGHT = map.GetLength(0);
            int WIDTH = map.GetLength(1);

            string[,] mapReport = new string[HEIGHT, WIDTH];
            for (int y = 0; y < HEIGHT; y++)
            {
                for (int x = 0; x< map.GetLength(0); x++)
                {
                    string curentCell = map[y, x];
                    if (curentCell.Equals("*"))
                    {
                        mapReport[y, x] = "*";
                    }
                    else
                    {
                        int[,] NEIGHBOURS_ORDINATE = {
                        {y  - 1, x - 1}, {y - 1, x}, {y - 1, x + 1},
                        {y, x - 1}, {y, x + 1},
                        {y + 1, x - 1}, {y + 1, x}, {y + 1, x + 1},};

                        int minesAround = 0;
                        int length = NEIGHBOURS_ORDINATE.GetLength(0);
                        for (int i = 0; i < length; i++)
                        {
                            int xOrdinateOfNeighbour = NEIGHBOURS_ORDINATE[i, 1];
                            int yOrdinateOfNeighbour = NEIGHBOURS_ORDINATE[i, 0];

                            bool isOutOfMapNeighbour = xOrdinateOfNeighbour < 0
                                    || xOrdinateOfNeighbour == WIDTH
                                    || yOrdinateOfNeighbour < 0
                                    || yOrdinateOfNeighbour == HEIGHT;
                            if (isOutOfMapNeighbour)
                            {
                                continue;
                            }

                            bool isMineOwnerNeighbour = map[yOrdinateOfNeighbour, xOrdinateOfNeighbour].Equals("*");
                            if (isMineOwnerNeighbour)
                            {
                                minesAround++;
                            }
                        }

                        mapReport[y, x] = minesAround.ToString();
                    }
                }
            }

            for (int y = 0; y < HEIGHT; y++)
            {
                Console.WriteLine("\n");
                for (int x = 0; x < WIDTH; x++)
                {
                    String currentCellReport = mapReport[y, x];
                    Console.Write(currentCellReport);
                }
            }
            Console.ReadLine();
        }
    }
}