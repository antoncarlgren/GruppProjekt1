using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1
{
    /// <summary>
    /// Representerar en vägg. Går inte att gå på.
    /// </summary>
    public class TileWall : TileBase
    {
        public TileWall() : base()
        {
            IsWalkable = false;
            Glyph = '#';
        }
    }
}
