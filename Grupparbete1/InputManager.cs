using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1
{
    public static class InputManager
    {
        private static Dictionary<ConsoleKey, Point> DirectionPairs = new Dictionary<ConsoleKey, Point>()
        {
            { ConsoleKey.UpArrow, new Point(0, -1)},
            { ConsoleKey.DownArrow, new Point(0, 1)},
            { ConsoleKey.LeftArrow, new Point(-1, 0)},
            { ConsoleKey.RightArrow, new Point(1, 0)}
        };

        public static void ProcessInput(ConsoleKey input)
        {
            if (DirectionPairs.Keys.Contains(input))
            { 
                Program.Game.GameMap.Player.MoveBy(DirectionPairs[input].X, DirectionPairs[input].Y);
                Program.Game.GameMap.DrawMap();
            }
        }
    }
}
