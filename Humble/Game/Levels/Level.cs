using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humble
{
    public class Level : ICollidable
    {
        public Texture2D boundsTexture;

        public Level()
        {
            GraphicsDevice GraphicsDevice = GameService.GetService<GraphicsDevice>();
            boundsTexture = new Texture2D(GraphicsDevice, 1, 1);
            boundsTexture.SetData(new[] { Color.White });
        }

        /// Draw
        /// 

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(boundsTexture, Bounds, Color.White * 0.2f);
        }

        /// Collision
        /// 

        public virtual Rectangle Bounds
        {
            get
            {
                return new Rectangle(0, 0, 600, 600);
            }
        }

        public virtual bool Intersects(Rectangle rectangle)
        {
            return rectangle.Intersects(Bounds);
        }

        public virtual bool Contains(Vector2 point)
        {
            return Bounds.Contains(point.X, point.Y);
        }

        /// Custom
        /// 

        public virtual Vector2 getSpawnPoint()
        {
            return new Vector2(Bounds.Center.X, Bounds.Center.Y);
        }

    }

}
