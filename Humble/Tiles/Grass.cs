using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Humble.Tiles
{
    class Grass : Tile
    {
        public Grass(int x, int y)
        {
            rectangle = new Rectangle(x, y, 50, 50);
            this.color = Color.Green;
        }
    }
}
