using System;

namespace Grupparbete1
{
    class Program
    {
        private static Game Game;
        static void Main(string[] args)
        {
            Game = new Game(80, 25);
            Game.Init();
            Game.Run();
        }
    }
}
