using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Humble
{
    public abstract class IsometricBlock
    {
        public static int Width = 150;
        public static int Height = 180;

        public Vector2 position;
        public Rectangle positionRectangle;

        public Rectangle textureRectangle;
        public Texture2D texture;

        private int textureOffsetTop = 3;
        private int textureOffsetBottom = 5;
        private int textureOffsetLeft = 15;
        private int textureOffsetRight = 18;

        public IsometricBlock(Vector2 position)
        {
            this.position = position;
            // Create the rectangles that make up this block.
            positionRectangle = new Rectangle((int)position.X, (int)position.Y, Width, Height / 2);
            textureRectangle = new Rectangle((int)position.X - textureOffsetLeft,
                                             (int)position.Y - textureOffsetTop,
                                             Width + textureOffsetRight + textureOffsetLeft,
                                             Height + textureOffsetTop + textureOffsetBottom);
        }

        public Vector2 Center()
        {
            // Calculate the center of the physical position for this block.
            return new Vector2(positionRectangle.X + (positionRectangle.Width / 2), positionRectangle.Y + (positionRectangle.Height / 2));
        }

        public List<Vector2> getSurfaceAxis()
        {
            // Return a list of Axis' that are the presentation of the isometric surface area.
            List<Vector2> surfaceAxis = new List<Vector2>();
            surfaceAxis.Add(new Vector2(position.X + (positionRectangle.Width / 2), position.Y));
            surfaceAxis.Add(new Vector2(position.X + positionRectangle.Width, position.Y + positionRectangle.Height / 2));
            surfaceAxis.Add(new Vector2(position.X + positionRectangle.Width / 2, position.Y + positionRectangle.Height));
            surfaceAxis.Add(new Vector2(position.X, position.Y + positionRectangle.Height / 2));
            return surfaceAxis;
        }

        public Polygon getPolygon()
        {
            // Construct a Polygon representation for this block's surface.
            List<Vector2> surfaceAxis = getSurfaceAxis();
            return Polygon.AxisToPolygon(surfaceAxis);
        }

        public bool Intersects(Vector2 point)
        {
            // Check if a point lies within the surface area of this block.
            Polygon polygon = getPolygon();
            return polygon.Contains(point);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, textureRectangle, Color.White);
        }

    }
}
