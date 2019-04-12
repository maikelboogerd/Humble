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
                //new Vector2(10, 0) * 5,
                //new Vector2(20, 0) * 5,
                //new Vector2(30, 10) * 5,
                //new Vector2(30, 20) * 5,
                //new Vector2(20, 30) * 5,
                //new Vector2(10, 30) * 5,
                //new Vector2(0, 20) * 5,
                //new Vector2(0, 10) * 5,
            };
        }

        public Vector2 Center()
        {
            return new Vector2(50, 50);
        }

        public bool Contains(Vector2 player)
        {
            // Define vectorA list
            List<Vector2> vectorA = new List<Vector2>();
            for (int i = 0; i < innerPoints.Count; i++)
            {
                Vector2 vectorAx = new Vector2(player.X - innerPoints[i].X, player.Y - innerPoints[i].Y);
                vectorA.Add(vectorAx);
            }

            // Define vectorB list
            List<Vector2> vectorB = new List<Vector2>();
            for (int i = 0; i < innerPoints.Count; i++)
            {
                Vector2 vectorBx = new Vector2();
                Vector2 nextInnerpoint;

                Vector2 actualInnerpoint = innerPoints[i];
                int stepX = 0;
                int stepY = 0;

                if (i + 1 >= innerPoints.Count) {
                    nextInnerpoint = innerPoints[0];
                } else {
                    int next = i + 1;
                    nextInnerpoint = innerPoints[next];
                }

                float difX = nextInnerpoint.X - actualInnerpoint.X;
                float difY = nextInnerpoint.Y - actualInnerpoint.Y;

                if (difX > 0)
                {
                    stepX = 1;
                }
                else if (difX < 0)
                {
                    stepX = -1;
                }
                else {
                    stepX = 0;
                }

                if (difY > 0)
                {
                    stepY = 1;
                }
                else if (difY < 0)
                {
                    stepY = -1;
                }
                else {
                    stepY = 0;
                }
                vectorBx = new Vector2(stepX, stepY);
                vectorB.Add(vectorBx);
            }

            List<int> dotProducts = new List<int>();

            for (int i = 0; i < vectorB.Count; i++)
            {
                int dotProduct = (int)(vectorA[i].X * vectorB[i].X + vectorA[i].Y * vectorB[i].Y);
                dotProducts.Add(dotProduct);
            }

            bool containsNegative = dotProducts.Any(i => i < 0);

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

            foreach (Vector2 point in innerPoints)
            {
                spriteBatch.Draw(pointTexture, new Rectangle((int)point.X, (int)point.Y, 1, 1), Color.White);
            }
            //spriteBatch.Draw(pointTexture, new Rectangle((int)innerPoints[0].X, (int)innerPoints[0].Y, 1, 1), Color.White);
            //spriteBatch.Draw(pointTexture, new Rectangle((int)innerPoints[1].X, (int)innerPoints[1].Y, 1, 1), Color.White);
            //spriteBatch.Draw(pointTexture, new Rectangle((int)innerPoints[2].X, (int)innerPoints[2].Y, 1, 1), Color.White);
            //spriteBatch.Draw(pointTexture, new Rectangle((int)innerPoints[3].X, (int)innerPoints[3].Y, 1, 1), Color.White);
            //spriteBatch.Draw(pointTexture, new Rectangle(0, 0, 1, 1), Color.White);
            //spriteBatch.Draw(pointTexture, new Rectangle(90, 90, 1, 1), Color.White);
        }
    }
}
