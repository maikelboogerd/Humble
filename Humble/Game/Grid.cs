using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humble
{
    public class Grid
    {
        public int Width;
        public int Height;
        public List<IsometricBlock> blocks;

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
            blocks = new List<IsometricBlock>();
        }

        public void Fill()
        {
            // Loop over the rows/columns and create each block in order.
            for (int yIndex = 0; yIndex < Height; ++yIndex)
            {
                for (int xIndex = 0; xIndex < Width; ++xIndex)
                {
                    Vector2 position;

                    if (yIndex % 2 == 0)
                        position = new Vector2(xIndex * IsometricBlock.Width - (IsometricBlock.Width / 2), (yIndex * IsometricBlock.Height / 2) / 2);
                    else
                        position = new Vector2(xIndex * IsometricBlock.Width, (yIndex * IsometricBlock.Height / 2) / 2);

                    IsometricBlock isometricBlock = new Blocks.Grass(position);
                    blocks.Add(isometricBlock);
                }
            }
        }
    }
}
