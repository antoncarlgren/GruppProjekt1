using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupparbete1.Engine;
using Grupparbete1.MapData;

namespace Grupparbete1
{
    /// <summary>
    /// Innehåller den karta som används i spelet just nu, och tar emot input från spelaren.
    /// </summary>
    public class Game
    {
        public Map GameMap { get; set; }
        private MapGenerator _mapGen;

        public Game(int width, int height)
        {
            //GameMap = new Map(width, height);
            _mapGen = new MapGenerator(new Map(width, height), 10, 5, 12);
        }

        public void Init()
        {
            GameMap = _mapGen.Generate();
            GameMap.Init();
        }

        /// <summary>
        /// Själva gameloopen som läser användarens input.
        /// </summary>
        public void Run()
        {
            ConsoleKey input;

            while(true)
            {
                // Skickar den tangent som spelaren trycker på till InputManager, som sedan utför olika saker beroende på vilken tangent som tryckts på.
                InputManager.ProcessInput(Console.ReadKey().Key);
            }
        }
    }
}
