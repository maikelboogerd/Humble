using System;
using System.Collections.Generic;
using Differ.Data;
using Differ.Math;
using Differ.Sat;
using Humble;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Differ.Shapes
{
	public class Polygon : Shape
	{
		/** The vertices of this shape */
		private IList<Vector> _vertices {
			get {
				return _vertices;
			}

			set {
				_vertices = value;
				name = "polygon(sides:" + _vertices.Count + ")";
			}
		}
		public IList<Vector> vertices { get; set; }

		/** The transformed (rotated/scale) vertices cache */
		public IList<Vector> transformedVertices {
			get {

				if (!_transformed) {
		            _transformedVertices = new List<Vector>();
		            _transformed = true;

		            var _count = vertices.Count;

		            for (var i = 0; i < _count; i++) {
						_transformedVertices.Add( vertices[i].clone().transform( _transformMatrix ) );
		            }
		        }

		        return _transformedVertices;
			}
		}

		private IList<Vector> _transformedVertices;

		public Polygon (float x, float y, IList<Vector> vertices) : base(x, y)
		{
			_transformedVertices = new List<Vector>();
			this.vertices = vertices;
		}

		public override ShapeCollision test (Shape shape)
		{
			return shape.testPolygon(this, true);
		}

		public override ShapeCollision testCircle (Circle circle, bool flip = false)
		{
			return Sat2D.testCircleVsPolygon(circle, this, !flip);
		}

		public override ShapeCollision testPolygon (Polygon polygon, bool flip = false)
		{
			return Sat2D.testPolygonVsPolygon(this, polygon, flip);
		}

		public override RayCollision testRay (Ray ray)
		{
			return Sat2D.testRayVsPolygon(ray, this);
		}

		/** Helper to create an Ngon at x,y with given number of sides, and radius.
            A default radius of 100 if unspecified. Returns a ready made `Polygon` collision `Shape` */
		public static Polygon create(float x, float y, int sides, float radius) {
			if (sides < 3) {
				throw new ArgumentException("A polygon must have a least 3 sides.");
			}

			float rotation = (float)(System.Math.PI * 2) / sides;
			float angle;
			Vector vector;
			IList<Vector> vertices = new List<Vector>();

			for (var i = 0; i < sides; i++) {
				angle = (float)((i * rotation) + ((System.Math.PI - rotation) * 0.5));
	            vector = new Vector();
				vector.x = (float)System.Math.Cos(angle) * radius;
				vector.y = (float)System.Math.Sin(angle) * radius;
	            vertices.Add(vector);
			}

			return new Polygon(x, y, vertices);
		}

		/** Helper generate a rectangle at x,y with a given width/height and centered state.
            Centered by default. Returns a ready made `Polygon` collision `Shape` */
        public static Polygon rectangle(float x, float y, float width, float height, bool centered = true) {

        	var vertices = new List<Vector>();

	        if (centered) {

	            vertices.Add( new Vector( -width / 2, -height / 2) );
				vertices.Add( new Vector(  width / 2, -height / 2) );
				vertices.Add( new Vector(  width / 2,  height / 2) );
				vertices.Add( new Vector( -width / 2,  height / 2) );

	        } else {

				vertices.Add( new Vector( 0, 0 ) );
				vertices.Add( new Vector( width, 0 ) );
				vertices.Add( new Vector( width, height) );
				vertices.Add( new Vector( 0, height) );

	        }

	        return new Polygon(x,y,vertices);
        }

		/** Helper generate a square at x,y with a given width/height with given centered state.
            Centered by default. Returns a ready made `Polygon` collision `Shape` */
	    public static Polygon square(float x, float y, float width, bool centered = true) {
	        return rectangle(x, y, width, width, centered);
	    }

		/** Helper generate a triangle at x,y with a given radius.
            Returns a ready made `Polygon` collision `Shape` */
	    public static Polygon triangle(float x, float y, float radius) {
	        return create(x, y, 3, radius);
	    }

        void DrawLine(SpriteBatch spriteBatch, Vector2 start, Vector2 end)
        {
            GraphicsDevice GraphicsDevice = GameService.GetService<GraphicsDevice>();
            Texture2D texture = new Texture2D(GraphicsDevice, 1, 1);

            Vector2 edge = end - start;
            // calculate angle to rotate line
            float angle = (float)System.Math.Atan2(edge.Y, edge.X);


            spriteBatch.Draw(texture,
                new Rectangle(// rectangle defines shape of line and position of start of line
                    (int)start.X,
                    (int)start.Y,
                    (int)edge.Length(), //sb will strech the texture to fill this rectangle
                    1), //width of line, change this to make thicker line
                null,
                Color.Red, //colour of line
                angle,     //angle of line (calulated above)
                new Vector2(0, 0), // point in line about which to rotate
                SpriteEffects.None,
                0);

        }

		public void Draw(SpriteBatch spriteBatch){
            GraphicsDevice GraphicsDevice = GameService.GetService<GraphicsDevice>();
            Texture2D texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.Red });
			foreach (Vector vertice in vertices){
                //DrawLine(spriteBatch, vertice.x, vertice.y);
                spriteBatch.Draw(texture, new Rectangle((int)vertice.x, (int)vertice.y, 2, 2), Color.White * 0.5f);
			}
		}
	}
}
