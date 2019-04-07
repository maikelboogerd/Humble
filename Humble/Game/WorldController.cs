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
        Game game;
        World world;

        public WorldController(Game game) : base(game)
        {
            this.game = game;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public World CreateWorld()
        {
            Game.Components.Add(world = new World(game));
            return world;
        }

        public World GetWorld()
        {
            return world;
        }

        public void RemoveWorld(World world)
        {
            Game.Components.Remove(world);
        }
    }
}
