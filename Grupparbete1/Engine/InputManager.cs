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
        private static Dictionary<ConsoleKey, Point> DirectionPairs = new Dictionary<ConsoleKey, Point>()
        {
            { ConsoleKey.UpArrow, new Point(0, -1)},
            { ConsoleKey.DownArrow, new Point(0, 1)},
            { ConsoleKey.LeftArrow, new Point(-1, 0)},
            { ConsoleKey.RightArrow, new Point(1, 0)}
        };

        /// <summary>
        /// Kontrollerar vilken tangent som spelaren tryckt på, och kör kod beroende på input.
        /// </summary>
        /// <param name="input">Den tangent som spelaren trycker på, via Console.ReadKey</param>
        public static void ProcessInput(ConsoleKey input)
        {
            if (DirectionPairs.Keys.Contains(input))
            {
                Program.Game.GameMap.Player.MoveBy(DirectionPairs[input].X, DirectionPairs[input].Y);
            }
            else
            {
                return;
            }
        }
    }
}
