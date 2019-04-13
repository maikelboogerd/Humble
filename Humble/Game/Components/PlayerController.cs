using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Humble
{
    public class PlayerController : GameComponent
    {
        private Game game;
        private Player player;
        private List<Player> players;

        public PlayerController(Game game) : base(game)
        {
            this.game = game;
            players = new List<Player>();
        }

        public Player Create(Input input)
        {
            Game.Components.Add(player = new Player(game, input));
            players.Add(player);
            return player;
        }

        public Player Get()
        {
            return player;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}