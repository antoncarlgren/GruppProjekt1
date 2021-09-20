using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete1
{
    public class Enemy : Actor
    {
        public Enemy(int x, int y, string name) : base(x, y, name, 'X', 10, 2, 10)
        {
            
        }
    }
}
