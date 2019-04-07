using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Humble
{
    class Block : GameComponent
    {
        public Rectangle rectangle;
        //Texture2D texture;

        public Rectangle surface;
        public Texture2D texture;
        public Texture2D debugTexture;

        public Block(Game game, Rectangle rectangle) : base(game)
        {
            this.rectangle = rectangle;
            //texture = new Texture2D(game.GraphicsDevice, 1, 1);
            //texture.SetData(new[] { Color.LightSteelBlue });
            texture = game.Content.Load<Texture2D>("Blocks/isometric_0000");

            surface = rectangle;

            debugTexture = new Texture2D(game.GraphicsDevice, 1, 1);
            debugTexture.SetData(new[] { Color.LightSteelBlue });
        }

        public Vector2 Center()
        {
            return new Vector2(rectangle.X - rectangle.Width / 2, rectangle.Y - rectangle.Height / 2);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(debugTexture, rectangle, Color.White);
            spriteBatch.Draw(texture, surface, Color.White);
        }
    }
}
