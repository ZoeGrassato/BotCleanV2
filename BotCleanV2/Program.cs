using System;
using System.Collections.Generic;
using System.Linq;

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
            var closestTileToClean = FindClosestDirtyTile(dirtyTiles);
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

        static int[] FindClosestDirtyTile(List<int[]> tiles)
        {
            var closestTile = new int[2];

            var closestRow = tiles.Select(x => x[0]).Min();
            var closestColumn = tiles.Select(x => x[1]).Min();

            var closestRowDestination = tiles.FirstOrDefault(x => x[0] == closestRow);
            var closestColumnDestination = tiles.FirstOrDefault(x => x[1] == closestColumn);

            closestTile = closestColumnDestination[0] + closestColumnDestination[1] > closestRowDestination[0] + closestRowDestination[1]
                                     ? closestRowDestination : closestColumnDestination; //find the destination with the least amount of job; so either closest row or closest column
            return closestTile;
        }
    }
}
