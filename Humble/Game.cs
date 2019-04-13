using System;
using System.Collections.Generic;
using Differ;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Humble
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        Random random = new Random();

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Input input = new Input()
        {
            Up = Keys.W,
            Down = Keys.S,
            Left = Keys.A,
            Right = Keys.D,
            Shoot = Keys.Space,
        };

        public PlayerController playerController;
        public WorldController worldController;
        public ProjectileController projectileController;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            //graphics.ToggleFullScreen();
            Content.RootDirectory = "Content";
            Mouse.WindowHandle = Window.Handle;
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
            Components.Add(projectileController = new ProjectileController(this));

            World world = worldController.Create();
            Player player = playerController.Create(input);
            Camera camera = new Camera(player);

            GameService.AddService<GraphicsDevice>(GraphicsDevice);
            GameService.AddService<ContentManager>(Content);

            GameService.AddService<PlayerController>(playerController);
            GameService.AddService<WorldController>(worldController);
            GameService.AddService<ProjectileController>(projectileController);

            GameService.AddService<World>(world);
            GameService.AddService<Player>(player);
            GameService.AddService<Camera>(camera);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
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

            if (false)
            {
                Vector2 spawnPoint = playerController.Get().Center();
                Vector2 targetPoint = Cursor.Position;
                Projectile projectile = new Projectile(this);
                projectileController.Add(projectile);
                projectile.Spawn(spawnPoint);
                projectile.Shoot(targetPoint);
            }
            else if (Keyboard.GetState().IsKeyDown(input.Shoot))
            {
                Vector2 spawnPoint = playerController.Get().Center();
                Vector2 targetPoint = Cursor.Position;
                Projectile projectile = new Projectile(this);
                projectileController.Add(projectile);
                projectile.Spawn(spawnPoint);
                projectile.Shoot(targetPoint);
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

            // TODO: Draw.

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
