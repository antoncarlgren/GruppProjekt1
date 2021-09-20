using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1
{
    public class Game
    {
        public Map GameMap { get; set; }

        public Game(int width, int height)
        {
            GameMap = new Map(width, height);
        }

        public void Init()
        {
        }

        public void Run()
        {

        }
    }
}
