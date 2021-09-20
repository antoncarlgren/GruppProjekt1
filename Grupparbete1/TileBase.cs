using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1
{
    /// <summary>
    /// Abstrakt grundklass som representerar en ruta på spelbrädet.
    /// </summary>
    public abstract class TileBase
    {
        public bool IsWalkable { get; set; }
        public char Glyph { get; set; }
        protected TileBase()
        {
        }
    }
}
