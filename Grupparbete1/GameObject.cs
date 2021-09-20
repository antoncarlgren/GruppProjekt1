using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1
{
    /// <summary>
    /// Basklass som representerar alla spelobjekt som inte är Tiles, till exempel spelaren, fiender, eller items i spelvärlden.
    /// </summary>
    public class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string Name { get; set; }

        // Det tecken som representerar spelobjektet på spelkartan.
        public char Glyph { get; set; }

        protected GameObject(int x, int y, string name, char glyph)
        {
            X = x;
            Y = y;
            Name = name;
            Glyph = glyph;
        }
    }
}
