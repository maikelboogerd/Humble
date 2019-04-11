using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humble
{
    public class Shape
    {
        private Rectangle outerRectangle = new Rectangle(0, 0, 90, 90);

        private List<Vector2> outerPoints;
        private List<Vector2> innerPoints;

        public Shape()
        {
            outerPoints = new List<Vector2>()
            {
                new Vector2(outerRectangle.X, outerRectangle.Y),
                new Vector2(outerRectangle.X + outerRectangle.Width, outerRectangle.Y),
                new Vector2(outerRectangle.X, outerRectangle.Y + outerRectangle.Height),
                new Vector2(outerRectangle.X + outerRectangle.Width, outerRectangle.Y + outerRectangle.Height),
            };
            innerPoints = new List<Vector2>()
            {
                new Vector2(outerRectangle.X + (outerRectangle.Width / 2), outerRectangle.Y),
                new Vector2(outerRectangle.X + outerRectangle.Width, outerRectangle.Y + (outerRectangle.Height / 2)),
                new Vector2(outerRectangle.X + (outerRectangle.Width / 2), outerRectangle.Y + outerRectangle.Height),
                new Vector2(outerRectangle.X, outerRectangle.Y + (outerRectangle.Height / 2)),
            };
        }

        public Vector2 Center()
        {
            return new Vector2(50, 50);
        }

        public bool Contains(Vector2 player)
        {
            Vector2 vectorA1 = new Vector2(player.X - innerPoints[0].X, player.Y - innerPoints[0].Y);
            Vector2 vectorA2 = new Vector2(player.X - innerPoints[1].X, player.Y - innerPoints[1].Y);
            Vector2 vectorA3 = new Vector2(player.X - innerPoints[2].X, player.Y - innerPoints[2].Y);
            Vector2 vectorA4 = new Vector2(player.X - innerPoints[3].X, player.Y - innerPoints[3].Y);

            Vector2 vectorB1 = new Vector2(1, 1);
            Vector2 vectorB2 = new Vector2(-1, 1);
            Vector2 vectorB3 = new Vector2(-1, -1);
            Vector2 vectorB4 = new Vector2(1, -1);

            int dotProduct1 = (int)(vectorA1.X * vectorB1.X + vectorA1.Y * vectorB1.Y);
            int dotProduct2 = (int)(vectorA2.X * vectorB2.X + vectorA2.Y * vectorB2.Y);
            int dotProduct3 = (int)(vectorA3.X * vectorB3.X + vectorA3.Y * vectorB3.Y);
            int dotProduct4 = (int)(vectorA4.X * vectorB4.X + vectorA4.Y * vectorB4.Y);
            List<int> numArray = new List<int>();
            numArray.Add(dotProduct1);
            numArray.Add(dotProduct2);
            numArray.Add(dotProduct3);
            numArray.Add(dotProduct4);

            bool containsNegative = numArray.Any(i => i < 0);

            if (containsNegative == true)
            {
                return false;
            }
            return true;
        }

        public bool Intersects(Rectangle rectangle)
        {
            Vector2 player = new Vector2(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2);
            //return outerRectangle.Intersects(rectangle);
            return Contains(player);
            //return true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            GraphicsDevice GraphicsDevice = GameService.GetService<GraphicsDevice>();

            Texture2D texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.Blue });
            spriteBatch.Draw(texture, outerRectangle, Color.White * 0.5f);

            Texture2D pointTexture = new Texture2D(GraphicsDevice, 1, 1);
            pointTexture.SetData(new[] { Color.Yellow });
            //spriteBatch.Draw(pointTexture, new Rectangle((int)innerPoints[0].X, (int)innerPoints[0].Y, 1, 1), Color.White);
            //spriteBatch.Draw(pointTexture, new Rectangle((int)innerPoints[1].X, (int)innerPoints[1].Y, 1, 1), Color.White);
            //spriteBatch.Draw(pointTexture, new Rectangle((int)innerPoints[2].X, (int)innerPoints[2].Y, 1, 1), Color.White);
            //spriteBatch.Draw(pointTexture, new Rectangle((int)innerPoints[3].X, (int)innerPoints[3].Y, 1, 1), Color.White);
            spriteBatch.Draw(pointTexture, new Rectangle(0, 0, 1, 1), Color.White);
            spriteBatch.Draw(pointTexture, new Rectangle(90, 90, 1, 1), Color.White);
        }
    }
}
