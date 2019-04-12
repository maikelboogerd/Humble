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
        private Rectangle outerRectangle = new Rectangle(0, 0, 250, 250);

        private List<Vector2> outerPoints;
        private List<Vector2> innerPoints;

        public Shape()
        {
            outerPoints = new List<Vector2>()
            {
                //new Vector2(outerRectangle.X, outerRectangle.Y),
                //new Vector2(outerRectangle.X + outerRectangle.Width, outerRectangle.Y),
                //new Vector2(outerRectangle.X, outerRectangle.Y + outerRectangle.Height),
                //new Vector2(outerRectangle.X + outerRectangle.Width, outerRectangle.Y + outerRectangle.Height),
            };
            innerPoints = new List<Vector2>()
            {
                // new Vector2(outerRectangle.X + (outerRectangle.Width / 2), outerRectangle.Y),
                // new Vector2(outerRectangle.X + outerRectangle.Width, outerRectangle.Y + (outerRectangle.Height / 2)),
                // new Vector2(outerRectangle.X + (outerRectangle.Width / 2), outerRectangle.Y + outerRectangle.Height),
                // new Vector2(outerRectangle.X, outerRectangle.Y + (outerRectangle.Height / 2)),

                // 8 figure
                //new Vector2(10, 0) * 5,
                //new Vector2(20, 0) * 5,
                //new Vector2(30, 10) * 5,
                //new Vector2(30, 20) * 5,
                //new Vector2(20, 30) * 5,
                //new Vector2(10, 30) * 5,
                //new Vector2(0, 20) * 5,
                //new Vector2(0, 10) * 5,

                // new 8 figure
                new Vector2(10, 10) * 5,
                new Vector2(25, 5) * 5,
                new Vector2(40, 10) * 5,
                new Vector2(45, 25) * 5,
                new Vector2(40, 40) * 5,
                new Vector2(25, 45) * 5,
                new Vector2(10, 40) * 5,
                new Vector2(5, 25) * 5,
            };
        }

        public Vector2 Center()
        {
            return new Vector2(125, 125);
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
                int stepX = 1;
                int stepY = 1;

                if (i + 1 >= innerPoints.Count) {
                    nextInnerpoint = innerPoints[0];
                } else {
                    int next = i + 1;
                    nextInnerpoint = innerPoints[next];
                }

                float difX = nextInnerpoint.X - actualInnerpoint.X;
                float difY = nextInnerpoint.Y - actualInnerpoint.Y;

                if (Math.Abs(difY) > Math.Abs(difX))
                {
                    stepY = Math.Abs((Convert.ToInt32(difY) / Convert.ToInt32(difX)));
                }
                if (difY < 0 )
                {
                    stepY *= -1;
                } else if (difY == 0)
                {
                    stepY = 0;
                }

                if (Math.Abs(difX) >= Math.Abs(difY))
                {
                    stepX = Math.Abs((Convert.ToInt32(difX) / Convert.ToInt32(difY)));
                }

                if (difX < 0)
                {
                    stepX *= -1;
                }
                else if (difX == 0)
                {
                    stepX = 0;
                }

                vectorBx = new Vector2(stepX, stepY);
                //vectorB.Add(vectorBx);
            }

            vectorB.Add(new Vector2(1, 0));
            vectorB.Add(new Vector2(1, 1));
            vectorB.Add(new Vector2(0, 1));
            vectorB.Add(new Vector2(-1, 1));
            vectorB.Add(new Vector2(-1, 0));
            vectorB.Add(new Vector2(-1, -1));
            vectorB.Add(new Vector2(0, -1));
            vectorB.Add(new Vector2(1, -1));

            // double lenB = Math.Sqrt(vectorB[0].X * vectorB[0].X + vectorB[0].Y * vectorB[0].Y);
            // List<Vector2> dpx = new List<Vector2>();
            // for (int i = 0; i < vectorB.Count; i++)
            // {
            //     double bX = vectorB[i].X / lenB;
            //     double bY = vectorB[i].Y / lenB;
            //     dpx.Add(new Vector2((float)bX, (float)bY));
            // }

            List<int> dotProducts = new List<int>();
            for (int i = 0; i < vectorB.Count; i++)
            {
                // int dotProduct = (int)(vectorA[i].X * dpx[i].X + vectorA[i].Y * dpx[i].Y);
                int dotProduct = (int)(vectorA[i].X * vectorB[i].X + vectorA[i].Y * vectorB[i].Y);
                Console.WriteLine(dotProduct);
                dotProducts.Add(dotProduct);
            }

            Console.WriteLine("------------");
            // for(int i = 0; i < dotProducts.Count; i++)
            // {
            //     Console.WriteLine(dotProducts[i]);
            // }`

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
