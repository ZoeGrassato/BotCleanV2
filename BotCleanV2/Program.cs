using System;
using System.Collections.Generic;
using System.Linq;

namespace BotCleanV2
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new String[] { "- - - - -", "- - - - -", "- - - d -", "- - - d -", "- - d - d" };
            NextMove(1,3, board);
        }

        static void NextMove(int posr, int posc, String[] board)
        {
            var instruction = "";
            var currentPositionOfBot = new int[] { posr, posc };
            var dirtyTiles = FindDirtyTiles(board);
            var closestTileToClean = FindClosestDirtyTile(dirtyTiles, currentPositionOfBot);

            //First move RIGHT/LEFT then DOWN/UP
            if (closestTileToClean[0] == -1 && closestTileToClean[1] == -1) instruction = "CLEAN";
            else if (currentPositionOfBot[1] - closestTileToClean[1] != 0) instruction = currentPositionOfBot[1] - closestTileToClean[1] < 0 ? "RIGHT" : "LEFT";
            else if (currentPositionOfBot[0] - closestTileToClean[0] != 0) instruction = currentPositionOfBot[0] - closestTileToClean[0] < 0 ? "DOWN" : "UP"; //if this is equal to 0 then we are done moving rows

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
            var closestDifference = Int32.MaxValue;

            for(int i = 0; i < tiles.Count; i++)
            {
                var currentDistanceFromBotRow = Math.Abs(botCurrentPosition[0] - tiles[i][0]);
                var currentDistanceFromBotCol = Math.Abs(botCurrentPosition[1] - tiles[i][1]);

                if(botCurrentPosition[0] == tiles[i][0] && botCurrentPosition[1] == tiles[i][1])
                {
                    closestTile = new int[] { -1, -1 };
                    return closestTile;
                }

                if (currentDistanceFromBotRow + currentDistanceFromBotCol < closestDifference )
                {
                    closestDifference = currentDistanceFromBotRow + currentDistanceFromBotCol;
                    closestTile = new int[] { tiles[i][0], tiles[i][1] };
                }
            }
            return closestTile;
        }
    }
}
