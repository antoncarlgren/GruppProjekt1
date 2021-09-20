﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1
{
    /// <summary>
    /// Representerar en golvruta, som går at gå på.
    /// </summary>
    public class TileFloor : TileBase
    {
        public TileFloor() : base()
        {
            IsWalkable = true;
            Glyph = '.';
        }
    }
}
