using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Humble
{
    public class Sprite
    {
        private Texture2D _texture;
        public Vector2 Position;
        public float Speed = 2;
        public Input Input;

        public Sprite(Texture2D texture) 
        {
            _texture = texture;
        }

        public void Update() 
        {
            Move();
        }
        public void Move()
        { 
            if (Input == null) 
            {
                return;
            }

            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                // up
                Position.Y -= Speed;
            }

            if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                // down
                Position.Y += Speed;
            }
            if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                // right
                Position.X += Speed;
            }
            if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                // left
                Position.X -= Speed;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }
    }
}

