using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Humble
{
    public class Player : DrawableGameComponent
    {
        Game game;
        Input input;
        SpriteBatch spriteBatch;

        public float movementSpeed = 5;
        public float speedModifier = 1;

        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;

        public Player(Game game, Input input) : base(game)
        {
            this.game = game;
            this.input = input;
        }

        public override void Initialize()
        {
            Console.WriteLine("@Player.Initialize");

            spriteBatch = new SpriteBatch(GraphicsDevice);

            texture = Game.Content.Load<Texture2D>("Box");
            position = new Vector2(100, 100);
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            //Console.WriteLine("@Player.Update");
            Move();
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, Color.White);
            spriteBatch.End();
        }

        public Boolean canMoveTo(Vector2 position)
        {
            Rectangle targetRectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            if (game.worldController.GetWorld().Intersects(targetRectangle))
                return true;

            return false;
        }

        public void Move()
        {
            Console.WriteLine("@Player.Move");

            Vector2 targetPosition = position;

            if (Keyboard.GetState().IsKeyDown(input.Up))
                targetPosition.Y -= (movementSpeed * speedModifier);

            if (Keyboard.GetState().IsKeyDown(input.Down))
                targetPosition.Y += (movementSpeed * speedModifier);

            if (Keyboard.GetState().IsKeyDown(input.Right))
                targetPosition.X += (movementSpeed * speedModifier);

            if (Keyboard.GetState().IsKeyDown(input.Left))
                targetPosition.X -= (movementSpeed * speedModifier);

            Rectangle targetRectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            if (game.worldController.GetWorld().Intersects(targetRectangle))

                if (canMoveTo(targetPosition))
                    position = targetPosition;
                    rectangle.X = (int)position.X;
                    rectangle.Y = (int)position.Y;
        }
    }
}
