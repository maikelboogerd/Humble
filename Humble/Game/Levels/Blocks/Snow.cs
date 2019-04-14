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
    public class Snow : IsometricBlock
    {
        public Snow(Vector2 position) : base(position)
        {
            ContentManager Content = GameService.GetService<ContentManager>();
            texture = Content.Load<Texture2D>("Blocks/isometric_0043");
        }
    }
}
