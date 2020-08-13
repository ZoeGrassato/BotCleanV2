using System;
using System.Collections.Generic;

namespace BotCleanV2
{
    class Program
    {
        static void Main(string[] args)
        {
            String temp = Console.ReadLine();
            String[] position = temp.Split(' ');
            int[] pos = new int[2];
            String[] board = new String[5];
            for (int i = 0; i < 5; i++)
            {
                board[i] = Console.ReadLine();
            }
            for (int i = 0; i < 2; i++) pos[i] = Convert.ToInt32(position[i]);
            NextMove(pos[0], pos[1], board);
        }

        static void NextMove(int posr, int posc, String[] board)
        {
            var dirtyTiles = FindDirtyTiles(board);

        }

        static List<int[]> FindDirtyTiles(String[] tiles)
        {
            var dirtyTiles = new List<int[]>();
            for (int i = 0; i < tiles.Length; i++)
            {
                for (int j = 0; j < tiles.Length; j++)
                {
                    if (tiles[i] == "d") dirtyTiles.Add(new int[] { i, j });
                }
            }
            return dirtyTiles;
        }
    }
}
