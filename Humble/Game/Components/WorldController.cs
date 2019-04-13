using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Humble
{
    public class WorldController : GameComponent
    {
        private Game game;
        private World world;

        public WorldController(Game game) : base(game)
        {
            this.game = game;
        }

        /// Initialize
        /// 

        public override void Initialize()
        {
            Console.WriteLine("@WorldController.Initialize");
            base.Initialize();
        }

        /// Update
        /// 

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// Custom
        /// 

        public World Create()
        {
            Console.WriteLine(">> WorldController.Create");
            Game.Components.Add(world = new World(game));
            return world;
        }

        public World Get()
        {
            return world;
        }

        public void Remove(World world)
        {
            Game.Components.Remove(world);
            world = null;
        }

    }
}
