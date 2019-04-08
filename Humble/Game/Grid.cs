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
        private List<int> Layout;
        public List<IsometricBlock> blocks;

        public Grid(List<int> layout)
        {
            Layout = layout;
            blocks = new List<IsometricBlock>();
        }

        public void Fill(TypedDictionary blockMapping)
        {
            // Loop over the rows/columns and create each block in order.
            for (int yIndex = 0; yIndex < Height; ++yIndex)
            {
                for (int xIndex = 0; xIndex < Width; ++xIndex)
                {
                    Vector2 position;
                    int loopIndex = (Math.Max(xIndex, 1) * Math.Max(yIndex, 1)) - 1;

                    if (yIndex % 2 == 0)
                        position = new Vector2(xIndex * IsometricBlock.Width - (IsometricBlock.Width / 2), (yIndex * IsometricBlock.Height / 2) / 2);
                    else
                        position = new Vector2(xIndex * IsometricBlock.Width, (yIndex * IsometricBlock.Height / 2) / 2);

                    // Fetch the int <> block type from the mapping and create the instance.
                    Type blockClass = blockMapping.Get(Layout[loopIndex]);
                    IsometricBlock instance = (IsometricBlock)Activator.CreateInstance(blockClass, position);

                    blocks.Add(instance);
                }
            }
        }

        public int Width
        {
            get
            {
                return (int)Math.Sqrt(Layout.Count);
            }
        }

        public int Height
        {
            get
            {
                return (int)Math.Sqrt(Layout.Count);
            }
        }
    }
}
