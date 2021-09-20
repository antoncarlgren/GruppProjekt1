using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1
{
    public abstract class TileBase
    {
        public bool IsWalkable { get; set; }
        public char Glyph { get; set; }
        protected TileBase()
        {
        }
    }
}
