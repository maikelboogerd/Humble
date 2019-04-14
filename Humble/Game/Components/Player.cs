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
    public class Player : DrawableGameComponent, ICollidable, IMovable, ISpawnable, IKillable
    {
        private SpriteBatch spriteBatch;
        private Texture2D boundsTexture;
        private Texture2D playerTexture;

        public enum State
        {
            IDLE,
            ATTACKING,
            TRAVELING,
            DEATH,
        }

        public State currentState;

        public Input input;
        public int MovementSpeed = 10;

        public Player(Game game, Input input) : base(game)
        {
            this.input = input;
            DrawOrder = 1;
        }

        /// Initialize
        /// 

        public override void Initialize()
        {
            Console.WriteLine("@Player.Initialize");
            base.Initialize();
        }

        /// Load
        /// 

        protected override void LoadContent()
        {
            Console.WriteLine("@Player.LoadContent");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            boundsTexture = new Texture2D(GraphicsDevice, 1, 1);
            boundsTexture.SetData(new[] { Color.Green });
        }

        /// Update
        /// 

        public override void Update(GameTime gameTime)
        {
        }

        /// Draw
        /// 

        public override void Draw(GameTime gameTime)
        {
            Camera camera = GameService.GetService<Camera>();
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, Matrix.CreateTranslation(camera.Position));
            spriteBatch.Draw(boundsTexture, Bounds, Color.White * 1.0f);
            spriteBatch.End();
        }

        /// Collision
        /// 

        public int Width = 20;
        public int Height = 20;

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)Position.X - (Width / 2), (int)Position.Y - (Height / 2), Width, Height);
            }
        }

        public bool Intersects(Rectangle rectangle)
        {
            return rectangle.Intersects(Bounds);
        }

        public bool Contains(Vector2 point)
        {
            return Bounds.Contains(point.X, point.Y);
        }

        /// Movement
        /// 

        public Vector2 Position { get; set; }

        public void ChangePosition(Vector2 location)
        {
            Position = location;
        }

        /// Spawning
        /// 

        public Vector2 SpawnPoint { get; set; }

        public void Spawn(Vector2 spawnPoint)
        {
            SpawnPoint = spawnPoint;
            ChangePosition(spawnPoint);
            currentState = State.IDLE;
        }

        public void Respawn()
        {
            Spawn(SpawnPoint);
        }

        /// Damage
        /// 

        public void Kill()
        {
            currentState = State.DEATH;
        }

        public bool IsDeath()
        {
            return currentState == State.DEATH;
        }

    }

    public class OldPlayer : DrawableGameComponent
    {
        private Game game;
        private Input input;
        private SpriteBatch spriteBatch;

        private int boundsSize = 20;
        private int playerSize = 40;
        private float movementSpeed = 4;
        private float speedModifier = 1;

        public Vector2 position;
        public Rectangle positionBounds;
        public Rectangle playerBounds;

        private Texture2D positionTexture;
        private Texture2D playerTexture;

        public String state = null;
        public String latestState = null;

        Animation walkDown;
        Animation walkLeft;
        Animation walkRight;
        Animation walkUp;

        Animation standDown;
        Animation standUp;
        Animation standLeft;
        Animation standRight;

        Animation currentAnimation;

        public int frameWidth = 64;
        public int frameHeight = 64;

        public OldPlayer(Game game, Input input) : base(game)
        {
            Console.WriteLine("@Player.Constructor");
            Console.WriteLine(input);
            DrawOrder = 1;
            this.game = game;
            this.input = input;
        }

        /// Initialize
        /// 

        public override void Initialize()
        {
            Console.WriteLine("@Player.Initialize");
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

            playerTexture = Game.Content.Load<Texture2D>("charactersheet");

            walkUp = new Humble.Animation();
            walkUp.AddFrame(new Rectangle(64 * 0, 0, 64, 64), TimeSpan.FromSeconds(0.25));
            walkUp.AddFrame(new Rectangle(64 * 1, 0, 64, 64), TimeSpan.FromSeconds(0.25));
            walkUp.AddFrame(new Rectangle(64 * 2, 0, 64, 64), TimeSpan.FromSeconds(0.25));
            walkUp.AddFrame(new Rectangle(64 * 3, 0, 64, 64), TimeSpan.FromSeconds(0.25));
            walkUp.AddFrame(new Rectangle(64 * 4, 0, 64, 64), TimeSpan.FromSeconds(0.25));
            walkUp.AddFrame(new Rectangle(64 * 5, 0, 64, 64), TimeSpan.FromSeconds(0.25));
            walkUp.AddFrame(new Rectangle(64 * 6, 0, 64, 64), TimeSpan.FromSeconds(0.25));
            walkUp.AddFrame(new Rectangle(64 * 7, 0, 64, 64), TimeSpan.FromSeconds(0.25));
            walkUp.AddFrame(new Rectangle(64 * 8, 0, 64, 64), TimeSpan.FromSeconds(0.25));

            walkDown = new Humble.Animation();
            walkDown.AddFrame(new Rectangle(64 * 0, 128, 64, 64), TimeSpan.FromSeconds(0.25));
            walkDown.AddFrame(new Rectangle(64 * 1, 128, 64, 64), TimeSpan.FromSeconds(0.25));
            walkDown.AddFrame(new Rectangle(64 * 2, 128, 64, 64), TimeSpan.FromSeconds(0.25));
            walkDown.AddFrame(new Rectangle(64 * 3, 128, 64, 64), TimeSpan.FromSeconds(0.25));
            walkDown.AddFrame(new Rectangle(64 * 4, 128, 64, 64), TimeSpan.FromSeconds(0.25));
            walkDown.AddFrame(new Rectangle(64 * 5, 128, 64, 64), TimeSpan.FromSeconds(0.25));
            walkDown.AddFrame(new Rectangle(64 * 6, 128, 64, 64), TimeSpan.FromSeconds(0.25));
            walkDown.AddFrame(new Rectangle(64 * 7, 128, 64, 64), TimeSpan.FromSeconds(0.25));
            walkDown.AddFrame(new Rectangle(64 * 8, 128, 64, 64), TimeSpan.FromSeconds(0.25));

            walkLeft = new Humble.Animation();
            walkLeft.AddFrame(new Rectangle(64 * 0, 64, 64, 64), TimeSpan.FromSeconds(0.25));
            walkLeft.AddFrame(new Rectangle(64 * 1, 64, 64, 64), TimeSpan.FromSeconds(0.25));
            walkLeft.AddFrame(new Rectangle(64 * 2, 64, 64, 64), TimeSpan.FromSeconds(0.25));
            walkLeft.AddFrame(new Rectangle(64 * 3, 64, 64, 64), TimeSpan.FromSeconds(0.25));
            walkLeft.AddFrame(new Rectangle(64 * 4, 64, 64, 64), TimeSpan.FromSeconds(0.25));
            walkLeft.AddFrame(new Rectangle(64 * 5, 64, 64, 64), TimeSpan.FromSeconds(0.25));
            walkLeft.AddFrame(new Rectangle(64 * 6, 64, 64, 64), TimeSpan.FromSeconds(0.25));
            walkLeft.AddFrame(new Rectangle(64 * 7, 64, 64, 64), TimeSpan.FromSeconds(0.25));
            walkLeft.AddFrame(new Rectangle(64 * 8, 64, 64, 64), TimeSpan.FromSeconds(0.25));

            walkRight = new Humble.Animation();
            walkRight.AddFrame(new Rectangle(64 * 0, 192, 64, 64), TimeSpan.FromSeconds(0.25));
            walkRight.AddFrame(new Rectangle(64 * 1, 192, 64, 64), TimeSpan.FromSeconds(0.25));
            walkRight.AddFrame(new Rectangle(64 * 2, 192, 64, 64), TimeSpan.FromSeconds(0.25));
            walkRight.AddFrame(new Rectangle(64 * 3, 192, 64, 64), TimeSpan.FromSeconds(0.25));
            walkRight.AddFrame(new Rectangle(64 * 4, 192, 64, 64), TimeSpan.FromSeconds(0.25));
            walkRight.AddFrame(new Rectangle(64 * 5, 192, 64, 64), TimeSpan.FromSeconds(0.25));
            walkRight.AddFrame(new Rectangle(64 * 6, 192, 64, 64), TimeSpan.FromSeconds(0.25));
            walkRight.AddFrame(new Rectangle(64 * 7, 192, 64, 64), TimeSpan.FromSeconds(0.25));
            walkRight.AddFrame(new Rectangle(64 * 8, 192, 64, 64), TimeSpan.FromSeconds(0.25));

            // Standing animations only have a single frame of animation:
            standDown = new Animation();
            standDown.AddFrame(new Rectangle(0, 128, 64, 64), TimeSpan.FromSeconds(.25));

            standRight = new Animation();
            standRight.AddFrame(new Rectangle(0, 192, 64, 64), TimeSpan.FromSeconds(.25));

            standLeft = new Animation();
            standLeft.AddFrame(new Rectangle(0, 64, 64, 64), TimeSpan.FromSeconds(.25));

            standUp = new Animation();
            standUp.AddFrame(new Rectangle(0, 0, 64, 64), TimeSpan.FromSeconds(.25));

            currentAnimation = standDown;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Console.WriteLine("@Player.LoadContent");
        }

        public Vector2 Center()
        {
            return new Vector2(X, Y);
        }

        public int X
        {
            get
            {
                return positionBounds.X + positionBounds.Width / 2;
            }
        }

        public int Y
        {
            get
            {
                return positionBounds.Y + positionBounds.Height / 2;
            }
        }

        /// Update
        /// 

        public override void Update(GameTime gameTime)
        {
            if (state != null)
            {
                if (state == "walkRight")
                    currentAnimation = walkRight;
                if (state == "walkLeft")
                    currentAnimation = walkLeft;
                if (state == "walkUp")
                    currentAnimation = walkUp;
                if (state == "walkDown")
                    currentAnimation = walkDown;
            }
            else
            {
                //If the character was walking, we can set the standing animation
                //according to the walking animation that is playing:
                if (latestState == "walkRight")
                    currentAnimation = standRight;
                if (latestState == "walkLeft")
                    currentAnimation = standLeft;
                if (latestState == "walkUp")
                    currentAnimation = standUp;
                if (latestState == "walkDown")
                    currentAnimation = standDown;
                latestState = null;
                 //if none of the above code hit then the character
                 //is already standing, so no need to change the animation.
            }

            currentAnimation.Update(gameTime);
        }

        /// Draw
        /// 

        public override void Draw(GameTime gameTime)
        {
            Camera camera = GameService.GetService<Camera>();
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, Matrix.CreateTranslation(camera.Position));

            // TODO: Replace hardcoded values for position
            Vector2 topLeftOfSprite = new Vector2(this.position.X - 32, this.position.Y - 64);

            var sourceRectangle = currentAnimation.CurrentRectangle;
            spriteBatch.Draw(playerTexture, topLeftOfSprite, sourceRectangle, Color.White);

            // DEBUG 
            //spriteBatch.Draw(positionTexture, positionBounds, Color.White);

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

            state = null;

            if (Keyboard.GetState().IsKeyDown(input.Up))
            {
                targetPosition.Y -= positionModifier;
                state = "walkUp";
                latestState = "walkUp";
            }

            if (Keyboard.GetState().IsKeyDown(input.Down))
            {
                targetPosition.Y += positionModifier;
                state = "walkDown";
                latestState = "walkDown";
            }

            if (Keyboard.GetState().IsKeyDown(input.Right))
            {
                targetPosition.X += positionModifier;
                state = "walkRight";
                latestState = "walkRight";
            }

            if (Keyboard.GetState().IsKeyDown(input.Left))
            {
                targetPosition.X -= positionModifier;
                state = "walkLeft";
                latestState = "walkLeft";
            }

            Rectangle targetBounds = new Rectangle((int)targetPosition.X, (int)targetPosition.Y, 1, 1);

            changePosition(targetPosition);

        }
    }
}
