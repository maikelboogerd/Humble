using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Humble
{
    class World
    {
        public List<Tile> tiles;

        public void Update() {}

        public void Draw(GraphicsDevice GraphicsDevice, SpriteBatch spriteBatch)
        {
            foreach (var tile in tiles)
                tile.Draw(GraphicsDevice, spriteBatch);
        }
    }
}
