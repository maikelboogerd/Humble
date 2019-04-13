using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Humble
{
    public class Cursor : IMovable
    {
        private Texture2D boundsTexture;
        private Player player;

        public Cursor(Player player)
        {
            this.player = player;
            GraphicsDevice GraphicsDevice = GameService.GetService<GraphicsDevice>();
            boundsTexture = new Texture2D(GraphicsDevice, 1, 1);
            boundsTexture.SetData(new[] { Color.Yellow });
        }

        /// Draw
        /// 

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(boundsTexture, Bounds, Color.White * 0.5f);
        }

        /// Collision
        /// 

        public Rectangle Bounds
        {
            get
            {
                int width = 5;
                int height = 5;
                return new Rectangle((int)Position.X - (width / 2), (int)Position.Y - (height / 2), width, height);
            }
        }

        /// Movement
        /// 

        public Vector2 Position
        {
            get
            {
                MouseState mouse = Mouse.GetState();
                return new Vector2(mouse.X, mouse.Y) + player.Position;
            }
            set
            {
            }
        }

        public void ChangePosition(Vector2 location)
        {
            Mouse.SetPosition((int)location.X, (int)location.Y);
        }

    }
}
