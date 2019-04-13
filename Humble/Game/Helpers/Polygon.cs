using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humble
{
    public class Polygon
    {
        private List<Vector> points = new List<Vector>();
        private List<Vector> edges = new List<Vector>();

        public void BuildEdges()
        {
            Vector p1;
            Vector p2;
            edges.Clear();
            for (int i = 0; i < points.Count; i++)
            {
                p1 = points[i];
                if (i + 1 >= points.Count)
                {
                    p2 = points[0];
                }
                else
                {
                    p2 = points[i + 1];
                }
                edges.Add(p2 - p1);
            }
        }

        public List<Vector> Edges
        {
            get { return edges; }
        }

        public List<Vector> Points
        {
            get { return points; }
        }

        public Vector Center
        {
            get
            {
                float totalX = 0;
                float totalY = 0;
                for (int i = 0; i < points.Count; i++)
                {
                    totalX += points[i].X;
                    totalY += points[i].Y;
                }

                return new Vector(totalX / (float)points.Count, totalY / (float)points.Count);
            }
        }

        public void Offset(Vector v)
        {
            Offset(v.X, v.Y);
        }

        public void Offset(float x, float y)
        {
            for (int i = 0; i < points.Count; i++)
            {
                Vector p = points[i];
                points[i] = new Vector(p.X + x, p.Y + y);
            }
        }

        public override string ToString()
        {
            string result = "";

            for (int i = 0; i < points.Count; i++)
            {
                if (result != "") result += " ";
                result += "{" + points[i] + "}";
            }

            return result;
        }

        public void Draw(SpriteBatch spriteBatch, Polygon polygon)
        {
            GraphicsDevice GraphicsDevice = GameService.GetService<GraphicsDevice>();

            Texture2D texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.Blue });
            spriteBatch.Draw(texture, polygon, Color.White * 0.5f);

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
