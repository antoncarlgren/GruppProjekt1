﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1
{
    public class Actor : Entity
    {
        public Actor(int x, int y, string name, char glyph) : base(x, y, name, glyph)
        {

        }

        public bool MoveBy(int deltaX, int deltaY)
        {
            if (X + deltaX > 0 && X + deltaX < Program.Game.GameMap.Width && Y + deltaY > 0 && Y + deltaY < Program.Game.GameMap.Height)
            {
                if (Program.Game.GameMap.TileGrid[X + deltaX][Y + deltaY].IsWalkable)
                {
                    X += deltaX;
                    Y += deltaY;
                    return true;
                }
            }

            return false;
        }
    }
}
