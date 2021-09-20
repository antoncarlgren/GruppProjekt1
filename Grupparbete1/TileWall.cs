using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1
{
    public class TileWall : TileBase
    {
        public TileWall() : base()
        {
            IsWalkable = false;
            Glyph = '#';
        }
    }
}
