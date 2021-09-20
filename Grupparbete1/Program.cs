using System;

namespace Grupparbete1
{
    class Program
    {
        public static Game Game;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Game = new Game(80, 25);
            Game.Init();
            Game.Run();
        }
    }
}
