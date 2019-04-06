using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Humble.Worlds
{
    class Dungeon : World
    {
        public Dungeon()
        {
            tiles = new List<Tile>();

            // 0
            tiles.Add(new Tiles.Grass(0, 0));
            tiles.Add(new Tiles.Grass(50, 0));
            tiles.Add(new Tiles.Grass(100, 0));
            tiles.Add(new Tiles.Grass(150, 0));
            tiles.Add(new Tiles.Water(200, 0));
            tiles.Add(new Tiles.Water(250, 0));
            tiles.Add(new Tiles.Grass(300, 0));
            // 50
            tiles.Add(new Tiles.Water(0, 50));
            tiles.Add(new Tiles.Grass(50, 50));
            tiles.Add(new Tiles.Grass(100, 50));
            tiles.Add(new Tiles.Grass(150, 50));
            tiles.Add(new Tiles.Grass(200, 50));
            tiles.Add(new Tiles.Grass(250, 50));
            // 100
            tiles.Add(new Tiles.Grass(0, 100));
            tiles.Add(new Tiles.Grass(50, 100));
            tiles.Add(new Tiles.Water(100, 100));
            tiles.Add(new Tiles.Water(150, 100));
            tiles.Add(new Tiles.Water(200, 100));
            tiles.Add(new Tiles.Grass(250, 100));
            tiles.Add(new Tiles.Grass(300, 100));
            // 150
            tiles.Add(new Tiles.Grass(0, 150));
            tiles.Add(new Tiles.Water(50, 150));
            tiles.Add(new Tiles.Grass(100, 150));
            tiles.Add(new Tiles.Grass(150, 150));
            tiles.Add(new Tiles.Water(200, 150));

        }
    }
}
