using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humble.Blocks
{
    public class LavaBlock : IsometricBlock
    {
        public LavaBlock(Vector2 position) : base(position)
        {
            // Create the textures for Draw().
            ContentManager Content = GameService.GetService<ContentManager>();
            texture = Content.Load<Texture2D>("Blocks/isometric_0003");
        }
    }
}
