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

        List<Block> blocks;

        private List<Sprite> _sprites;

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
            blocks.Add(new Block(50, 30, 100, 100));
            blocks.Add(new Block(60, 600, 100, 100));
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
            var texture = Content.Load<Texture2D>("Box");
            _sprites = new List<Sprite>()
            {
                new Sprite(texture) {
                    Position = new Vector2(100, 100),
                    Input = new Input()
                    {
                        Down = Keys.D,
                        Up = Keys.W,
                        Left = Keys.A,
                        Right = Keys.D
                    }
                },
                new Sprite(texture) {
                    Position = new Vector2(100, 100),
                    Input = new Input()
                    {
                        Down = Keys.Down,
                        Up = Keys.Up,
                        Left = Keys.Left,
                        Right = Keys.Right
                    }
                },
            };
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

            foreach (var sprite in _sprites)
                sprite.Update();

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

            foreach (var sprite in _sprites)
                sprite.Draw(spriteBatch);

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
