using System;
using System.Collections.Generic;
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
        private Random random = new Random();

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public PlayerController playerController;
        public WorldController worldController;
        public ProjectileController projectileController;
        public EnemyController enemyController;
        public CollisionChecker collisionChecker;

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
            Console.WriteLine("@Game.Initialize");

            GameService.AddService<GraphicsDevice>(GraphicsDevice);
            GameService.AddService<ContentManager>(Content);

            Components.Add(worldController = new WorldController(this));
            Components.Add(playerController = new PlayerController(this));
            Components.Add(enemyController = new EnemyController(this));
            Components.Add(projectileController = new ProjectileController(this));

            GameService.AddService<ProjectileController>(projectileController);

            var player1 = playerController.Create(Input.Default());
            var world = worldController.Create();

            player1.Spawn(world.spawnPoint);

            if (true)
            {
                // Spawn another player.
                var player2 = playerController.Create(Input.Alternative());
                player2.Spawn(world.spawnPoint);
            }

            if (true)
            {
                // Spawn the enemy.
                for (int i = 0; i < 3; i++)
                {
                    var enemy = enemyController.Create();
                    enemy.Spawn(world.spawnPoint);
                }
            }

            if (true)
            {
                // Add collision checks.
                collisionChecker = new CollisionChecker(this);
                collisionChecker.playerController = playerController;
                collisionChecker.enemyController = enemyController;
                collisionChecker.projectileController = projectileController;
                Components.Add(collisionChecker);
            }

            Cursor cursor = new Cursor(player1);
            Camera camera = new Camera(player1);

            GameService.AddService<Camera>(camera);
            GameService.AddService<Cursor>(cursor);
            GameService.AddService<World>(world);

            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Console.WriteLine("@Game.LoadContent");
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

            Player player = playerController.Get();
            World world = worldController.Get();

            playerController.HandleMovement(world);
            playerController.HandleActions();

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
