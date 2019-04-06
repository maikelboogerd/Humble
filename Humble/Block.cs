using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Humble
{
    class Block
    {

        public Rectangle rectangle;

        public Block(int x, int y, int width, int height)
        {
            rectangle = new Rectangle(x, y, width, height);
        }

        public void Draw(GraphicsDevice GraphicsDevice, SpriteBatch spriteBatch)
        {
            Texture2D texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.White });

            spriteBatch.Draw(texture, rectangle, Color.Black);
        }

        public void Update()
        {

        }

    }
}
