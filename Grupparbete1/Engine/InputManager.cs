using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1.Engine
{
    /// <summary>
    /// Hanterar den input som kommer från spelaren i form av tangenttryckningar. Binder metoder till de tangenter som representerar dem, till exempel piltangenterna till att flytta på Player-objektet.
    /// </summary>
    public static class InputManager
    {
        /// <summary>
        /// Binder en tangent till en förändring i koordinater, som sedan används i Actor.MoveBy för att flytta en Actor på spelkartan.
        /// </summary>
        private static Dictionary<ConsoleKey, Coord> DirectionPairs = new Dictionary<ConsoleKey, Coord>()
        {
            { ConsoleKey.UpArrow, new Coord(0, -1)},
            { ConsoleKey.DownArrow, new Coord(0, 1)},
            { ConsoleKey.LeftArrow, new Coord(-1, 0)},
            { ConsoleKey.RightArrow, new Coord(1, 0)}
        };

        private static List<ConsoleKey> guessKeys = new List<ConsoleKey>()
        {
            ConsoleKey.D1,
            ConsoleKey.D2,
            ConsoleKey.D3,
            ConsoleKey.D4
        };

        /// <summary>
        /// Kontrollerar vilken tangent som spelaren tryckt på, och kör kod beroende på input.
        /// </summary>
        /// <param name="input">Den tangent som spelaren trycker på, via Console.ReadKey</param>
        public static void ProcessInput(ConsoleKeyInfo input)
        {
            switch (Program.Game.CurrentMode)
            {
                case ControlMode.Movement:
                    if (DirectionPairs.Keys.Contains(input.Key))
                    {
                        Program.Game.GameMap.Player.MoveBy(DirectionPairs[input.Key].X, DirectionPairs[input.Key].Y);
                    }
                    else
                    {
                        return;
                    }
                    break;
                case ControlMode.RiddleInput:
                    if(guessKeys.Contains(input.Key))
                    {
                        Program.Game.GameMap.CurrentRiddleTablet.Riddle.Guess(input.Key);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
