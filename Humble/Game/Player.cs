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
        private Game game;
        private Input input;
        private SpriteBatch spriteBatch;

        private int boundsSize = 20;
        private int playerSize = 40;
        private float movementSpeed = 5;
        private float speedModifier = 1;

        public Vector2 position;
        public Rectangle positionBounds;
        public Rectangle playerBounds;

        private Texture2D positionTexture;
        private Texture2D playerTexture;


        public Player(Game game, Input input) : base(game)
        {
            this.game = game;
            this.input = input;
        }

        /// Initialize
        /// 

        public override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            position = new Vector2(100, 100);

            positionBounds = new Rectangle((int)position.X - boundsSize / 2,
                                           (int)position.Y - boundsSize / 2,
                                           boundsSize,
                                           boundsSize);

            playerBounds = new Rectangle((int)position.X - playerSize / 2,
                                         (int)position.Y - playerSize * 2,
                                         playerSize,
                                         playerSize * 2);

            positionTexture = new Texture2D(game.GraphicsDevice, 1, 1);
            positionTexture.SetData(new[] { Color.Red });

            //playerTexture = Game.Content.Load<Texture2D>("Box");
            playerTexture = new Texture2D(game.GraphicsDevice, 1, 1);
            playerTexture.SetData(new[] { Color.Black });

            changePosition(game.worldController.GetWorld().spawnPoint());

            base.Initialize();
        }

        public Vector2 Center()
        {
            return new Vector2(positionBounds.X / 2, positionBounds.Y / 2);
        }

        /// Update
        /// 

        public override void Update(GameTime gameTime)
        {
            handleInput();
        }

        /// Draw
        /// 

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(playerTexture, playerBounds, Color.White);
            spriteBatch.Draw(positionTexture, positionBounds, Color.White);
            spriteBatch.End();
        }

        /// Movement
        /// 

        public void changePosition(Vector2 position)
        {
            // Update current position.
            this.position.X = position.X;
            this.position.Y = position.Y;
            // Update movement bounds.
            positionBounds.X = (int)position.X - boundsSize / 2;
            positionBounds.Y = (int)position.Y - boundsSize / 2;
            // Update player bounds.
            playerBounds.X = (int)position.X - playerSize / 2;
            playerBounds.Y = (int)position.Y - playerSize * 2;
        }
        
        public void handleInput()
        {
            Vector2 targetPosition = position;

            float positionModifier = (movementSpeed * speedModifier);

            if (Keyboard.GetState().IsKeyDown(input.Up))
                targetPosition.Y -= positionModifier;

            if (Keyboard.GetState().IsKeyDown(input.Down))
                targetPosition.Y += positionModifier;

            if (Keyboard.GetState().IsKeyDown(input.Right))
                targetPosition.X += positionModifier;

            if (Keyboard.GetState().IsKeyDown(input.Left))
                targetPosition.X -= positionModifier;

            Rectangle targetBounds = new Rectangle((int)targetPosition.X, (int)targetPosition.Y, 1, 1);

            if (game.worldController.GetWorld().Intersects(targetBounds))
                changePosition(targetPosition);
        }
    }
}
