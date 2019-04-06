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

        Level level;
        List<Block> blocks;

        private Texture2D _texture;
        private Vector2 _position;
        
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
            // TODO: Add your initialization logic here

            base.Initialize();

            blocks = new List<Block>();
            blocks.Add(new Block(10, 20, 100, 100));
            blocks.Add(new Block(100, 100, 20, 20));
            blocks.Add(new Block(50, 30, 200, 20));
            blocks.Add(new Block(60, 600, 30, 100));
            blocks.Add(new Block(200, 200, 100, 100));

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _texture = Content.Load<Texture2D>("Box");
            _position = new Vector2(0, 0);
            // TODO: use this.Content to load your game content here
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




            if(Keyboard.GetState().IsKeyDown(Keys.W))
            {
                // up
                _position.Y -= 1;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                // down
                _position.Y += 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                // right
                _position.X += 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                // left
                _position.X -= 1;
            }

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

            foreach (Block block in blocks)
            {
                block.Draw(GraphicsDevice, spriteBatch);
            }

            spriteBatch.Draw(_texture, _position, Color.White);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
