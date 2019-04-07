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
        public static int Width = 180;
        public static int Height = 180;

        public Vector2 position;
        public Rectangle positionRectangle;
        public Rectangle surfaceRectangle;
        public Rectangle textureRectangle;

        public Texture2D positionTexture;
        public Texture2D surfaceTexture;
        public Texture2D blockTexture;
        public Texture2D centerTexture;

        private int textureOffsetTop = 3;
        private int textureOffsetBottom = 5;
        private int textureOffsetLeft = 15;
        private int textureOffsetRight = 18;

        public IsometricBlock(Game game, Vector2 position)
        {
            this.position = position;
            blockTexture = game.Content.Load<Texture2D>("Blocks/isometric_0011");

            positionRectangle = new Rectangle((int)position.X, (int)position.Y, Width, Height / 2);
            surfaceRectangle = new Rectangle((int)position.X + Width / 2, (int)position.Y, Width, Height);
            textureRectangle = new Rectangle((int)position.X - textureOffsetLeft,
                                             (int)position.Y - textureOffsetTop,
                                             Width + textureOffsetRight + textureOffsetLeft,
                                             Height + textureOffsetTop + textureOffsetBottom);

            positionTexture = new Texture2D(game.GraphicsDevice, 1, 1);
            positionTexture.SetData(new[] { Color.Red });

            surfaceTexture = new Texture2D(game.GraphicsDevice, 1, 1);
            surfaceTexture.SetData(new[] { Color.Blue });

            //blockTexture = new Texture2D(game.GraphicsDevice, 1, 1);
            //blockTexture.SetData(new[] { Color.Green });

            centerTexture = new Texture2D(game.GraphicsDevice, 1, 1);
            centerTexture.SetData(new[] { Color.Yellow });

        }

        public Vector2 Center()
        {
            return new Vector2(positionRectangle.X + (positionRectangle.Width / 2), positionRectangle.Y + (positionRectangle.Height / 2));
        }

        public List<Vector2> getSurfaceAxis()
        {
            List<Vector2> surfaceAxis = new List<Vector2>();
            surfaceAxis.Add(new Vector2(position.X + (positionRectangle.Width / 2), position.Y));
            surfaceAxis.Add(new Vector2(position.X + positionRectangle.Width, position.Y + positionRectangle.Height / 2));
            surfaceAxis.Add(new Vector2(position.X + positionRectangle.Width / 2, position.Y + positionRectangle.Height));
            surfaceAxis.Add(new Vector2(position.X, position.Y + positionRectangle.Height / 2));
            return surfaceAxis;
        }

        public List<Vector2> getRectangleAxis(Rectangle rectangle)
        {
            List<Vector2> rectangleAxis = new List<Vector2>();
            rectangleAxis.Add(new Vector2(position.X, position.Y));
            rectangleAxis.Add(new Vector2(position.X + positionRectangle.Width, position.Y));
            rectangleAxis.Add(new Vector2(position.X + positionRectangle.Width, position.Y + positionRectangle.Height));
            rectangleAxis.Add(new Vector2(position.X, position.Y + positionRectangle.Height));
            return rectangleAxis;
        }

        public bool Intersects(Vector2 point)
        {

            List<Vector2> surfaceAxis = getSurfaceAxis();
            Polygon surfacePolygon = Polygon.AxisToPolygon(surfaceAxis);

            return surfacePolygon.Contains(point);
            //return rectangle.Intersects(positionRectangle);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(blockTexture, textureRectangle, Color.White);
            //spriteBatch.Draw(positionTexture, positionRectangle, Color.White * 0.5f);
            //spriteBatch.Draw(surfaceTexture, surfaceRectangle, Color.White * 0.5f);
            //spriteBatch.Draw(surfaceTexture, surfaceRectangle, null, Color.White * 0.5f, MathHelper.PiOver4, Vector2.Zero, SpriteEffects.None, 0);
            //spriteBatch.Draw(centerTexture, Center(), Color.White);

            foreach(Vector2 axis in getSurfaceAxis())
                spriteBatch.Draw(centerTexture, axis, Color.White);

            //foreach (Vector2 axis in getRectangleAxis(positionRectangle))
            //    spriteBatch.Draw(centerTexture, axis, Color.White);

        }

    }
}
