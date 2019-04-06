using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Humble.Tiles
{
    class Water : Tile
    {
        public Water(int x, int y)
        {
            rectangle = new Rectangle(x, y, 50, 50);
            this.color = Color.Blue;
        }
    }
}
