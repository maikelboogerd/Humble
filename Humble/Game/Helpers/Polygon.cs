using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humble
{
    public class Polygon
    {
        public List<PolygonLine> Lines;

        public Polygon() {
            Lines = new List<PolygonLine>();
        }

        public static Polygon AxisToPolygon(List<Vector2> axis)
        {
            Polygon polygon = new Polygon();
            for (int i = 0; i < axis.Count; ++i)
            {
                Vector2 pointA = axis[i];
                Vector2 pointB;

                if (i != axis.Count - 1)
                    pointB = axis[i + 1];
                else
                    pointB = axis[0];

                PolygonLine polygonLine = new PolygonLine(pointA, pointB);
                polygon.Lines.Add(polygonLine);
            }
            return polygon;
        }

        public bool Contains(Vector2 point)
        {
            // Check if the point lies within this Polygon.
            bool inside = false;
            foreach (var side in Lines)
            {
                if (point.Y > Math.Min(side.Start.Y, side.End.Y))
                {
                    if (point.Y <= Math.Max(side.Start.Y, side.End.Y))
                    {
                        if (point.X <= Math.Max(side.Start.X, side.End.X))
                        {
                            float xIntersection = side.Start.X + ((point.Y - side.Start.Y) / (side.End.Y - side.Start.Y)) * (side.End.X - side.Start.X);
                            if (point.X <= xIntersection)
                            {
                                inside = !inside;
                            }
                        }
                    }
                }
            }
            return inside;
        }
    }

    public class PolygonLine
    {
        public Vector2 Start;
        public Vector2 End;

        public PolygonLine(Vector2 start, Vector2 end) {
            Start = start;
            End = end;
        }
    }
}