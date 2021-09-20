using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1
{
    public class Entity
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string Name { get; set; }
        public char Glyph { get; set; }

        protected Entity(int x, int y, string name, char glyph)
        {
            X = x;
            Y = y;
            Name = name;
            Glyph = glyph;
        }
    }
}
