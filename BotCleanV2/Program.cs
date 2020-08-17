using System;
using System.Collections.Generic;
using System.Linq;

namespace BotCleanV2
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new String[] { "- - - d -", "- d d - -", "- - - - -", "- - - - -", "d - d - -" };
            NextMove(0,1, board);
        }

        static void NextMove(int posr, int posc, String[] board)
        {
            var instruction = "";
            var currentPositionOfBot = new int[] { posr, posc };
            var dirtyTiles = FindDirtyTiles(board);
            var closestTileToClean = FindClosestDirtyTile(dirtyTiles, currentPositionOfBot);

            //First move RIGHT/LEFT then DOWN/UP
            if (currentPositionOfBot[0] - closestTileToClean[0] != 0) instruction = currentPositionOfBot[0] - closestTileToClean[0] < 0 ? "DOWN" : "UP"; //if this is equal to 0 then we are done moving rows
            else if (currentPositionOfBot[1] - closestTileToClean[1] != 0) instruction = currentPositionOfBot[1] - closestTileToClean[1] < 0 ? "RIGHT" : "LEFT";
            else instruction = "CLEAN";

            Console.WriteLine(instruction);
        }

        static List<int[]> FindDirtyTiles(String[] tiles)
        {
            var dirtyTiles = new List<int[]>();
            for (int i = 0; i < tiles.Length; i++)
            {
                var convertedCharList = tiles[i].ToCharArray().Where(c => !char.IsWhiteSpace(c)).ToList();
                for (int j = 0; j < tiles.Length; j++)
                {
                    if (convertedCharList[j] == 'd') dirtyTiles.Add(new int[] { i, j });
                }
            }
            return dirtyTiles;
        }

        static int[] FindClosestDirtyTile(List<int[]> tiles, int[] botCurrentPosition)
        {
            var closestTile = new int[2];

            var closestRow = tiles.Select(x => x[0]).Min();
            var closestColumn = tiles.Select(x => x[1]).Min();

            var closestRowDestination = tiles.FirstOrDefault(x => x[0] == closestRow);
            var closestColumnDestination = tiles.FirstOrDefault(x => x[1] == closestColumn);

            //BELOW: this calculates the distance between the current bot position, and both of the possible routes (closest row or closest column)
            var currentBotPaddingRowA = Math.Abs(botCurrentPosition[0] - closestRowDestination[0]);
            var currentBotPaddingColA = Math.Abs(botCurrentPosition[1] - closestRowDestination[1]);

            var currentBotPaddingRowB = Math.Abs(botCurrentPosition[0] - closestColumnDestination[0]);
            var currentBotPaddingColB = Math.Abs(botCurrentPosition[1] - closestColumnDestination[1]);

            closestTile = currentBotPaddingRowB + currentBotPaddingColB > currentBotPaddingRowA + currentBotPaddingColA
                                     ? closestRowDestination : closestColumnDestination; //find the destination with the least amount of jumps; so either closest row or closest column
            return closestTile;
        }
    }
}
