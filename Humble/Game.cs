using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Humble
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public PlayerController playerController;
        public WorldController worldController;

        public IsometricBlock isometricBlock1;
        public IsometricBlock isometricBlock2;
        public IsometricBlock isometricBlock3;
        public IsometricBlock isometricBlock4;
        public IsometricBlock isometricBlock5;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Components.Add(playerController = new PlayerController(this));
            Components.Add(worldController = new WorldController(this));

            //int blockWidth = 180;
            // Top row
            //Vector2 position1 = new Vector2(100, 100);
            //isometricBlock1 = new IsometricBlock(this, position1);
            //Vector2 position2 = new Vector2(100 + blockWidth, 100);
            //isometricBlock2 = new IsometricBlock(this, position2);
            // Middle row
            //Vector2 position3 = new Vector2(100 + (blockWidth / 2), 100 + (blockWidth / 2) / 2);
            //isometricBlock3 = new IsometricBlock(this, position3);
            // Bottom row
            //Vector2 position5 = new Vector2(100 + blockWidth, 100 + (blockWidth / 2));
            //isometricBlock5 = new IsometricBlock(this, position5);
            //Vector2 position4 = new Vector2(100, 100 + (blockWidth / 2));
            //isometricBlock4 = new IsometricBlock(this, position4);

            worldController.CreateWorld();

            Input playerOneInput = new Input()
            {
                Up = Keys.W,
                Down = Keys.S,
                Left = Keys.A,
                Right = Keys.D
            };

            Input playerTwoInput = new Input()
            {
                Up = Keys.Up,
                Down = Keys.Down,
                Left = Keys.Left,
                Right = Keys.Right
            };

            playerController.CreatePlayer(playerOneInput);
            playerController.CreatePlayer(playerTwoInput);

            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // TODO: Draw on sprite.
            //isometricBlock1.Draw(spriteBatch);
            //isometricBlock2.Draw(spriteBatch);
            //isometricBlock3.Draw(spriteBatch);
            //isometricBlock4.Draw(spriteBatch);
            //isometricBlock5.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
