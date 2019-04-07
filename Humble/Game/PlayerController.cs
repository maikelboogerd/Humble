using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Humble
{
    public class PlayerController : GameComponent
    {
        private Game game;
        public List<Player> players;

        public PlayerController(Game game) : base(game)
        {
            this.game = game;
            players = new List<Player>();
        }

        public override void Update(GameTime gameTime)
        {
            if (players.Count > 0)
            {
                foreach (Player player in players)
                {
                    player.Update(gameTime);
                }
            }

            base.Update(gameTime);
        }

        public void CreatePlayer(Input input)
        {
            Player player = new Player(game, input);
            Game.Components.Add(player);
            players.Add(player);
        }

        public List<Player> GetPlayers()
        {
            return players;
        }
    }
}