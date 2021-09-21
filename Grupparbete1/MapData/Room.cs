using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1.MapData
{
    public class Room
    { 
        public Coord Position { get; }
        public Size Size { get; }
        public Rectangle Area { get; }
        public Room(Coord position, Size size)
        {
            Position = position;
            Size = size;
            Area = new Rectangle(Position.ToPoint(), Size);
        }
    }
}
