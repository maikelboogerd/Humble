using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Humble
{
    public class IsometricBlock
    {
        public Rectangle positionRectangle;
        public Rectangle surfaceRectangle;
        public Rectangle textureRectangle;

        public Texture2D positionTexture;
        public Texture2D surfaceTexture;
        public Texture2D blockTexture;
        public Texture2D centerTexture;

        public IsometricBlock(GraphicsDevice GraphicsDevice)
        {
            positionRectangle = new Rectangle(50, 50, 100, 100);
            surfaceRectangle = new Rectangle(100, 50, 100, 100);
            textureRectangle = new Rectangle(50, 50, 100, 200);

            positionTexture = new Texture2D(GraphicsDevice, 1, 1);
            positionTexture.SetData(new[] { Color.Red });

            surfaceTexture = new Texture2D(GraphicsDevice, 1, 1);
            surfaceTexture.SetData(new[] { Color.Blue });

            blockTexture = new Texture2D(GraphicsDevice, 1, 1);
            blockTexture.SetData(new[] { Color.Green });

            centerTexture = new Texture2D(GraphicsDevice, 1, 1);
            centerTexture.SetData(new[] { Color.Yellow });

        }

        public Vector2 Center()
        {
            return new Vector2(positionRectangle.X + (positionRectangle.Width / 2),
                               positionRectangle.Y + (positionRectangle.Height / 2));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(blockTexture, textureRectangle, Color.White);
            spriteBatch.Draw(positionTexture, positionRectangle, Color.White * 0.5f);
            spriteBatch.Draw(surfaceTexture, surfaceRectangle, null, Color.White * 0.5f, MathHelper.PiOver4, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.Draw(centerTexture, Center(), Color.White);
            Console.WriteLine("@IsometricBlock.Draw");
        }

    }
}
