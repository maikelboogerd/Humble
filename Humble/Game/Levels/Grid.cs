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

        public void Fill(ClassMapping blockMapping)
        {
            // Loop over the rows/columns and create each block in order.
            int rowYAxis = 0;

            int columnXAxis = 0;
            for (int loopIndex = 0; loopIndex < Layout.Count; ++loopIndex)
            {
                Vector2 position;

                if (loopIndex % Columns == 0)
                {
                    rowYAxis += 1;
                    columnXAxis = 0;
                }

                if (rowYAxis % 2 == 0)
                {
                    position = new Vector2((columnXAxis + 1) * IsometricBlock.Width - (IsometricBlock.Width / 2), (rowYAxis * IsometricBlock.Height / 2) / 2);
                }

                else
                {
                    position = new Vector2(columnXAxis * IsometricBlock.Width, (rowYAxis * IsometricBlock.Height / 2) / 2);
                }

                // Fetch the int <> block type from the mapping and create the instance.
                Type blockClass = blockMapping.Get(Layout[loopIndex]);
                IsometricBlock instance = (IsometricBlock)Activator.CreateInstance(blockClass, position);
                blocks.Add(instance);
                columnXAxis += 1;
            }
        }

        public int Columns
        {
            get
            {
                return (int)Math.Sqrt(Layout.Count);
            }
        }

        public int Rows
        {
            get
            {
                return (int)Math.Sqrt(Layout.Count);
            }
        }

        public int Width
        {
            get
            {
                return Columns * IsometricBlock.Width;
            }
        }

        public int Height
        {
            get
            {
                return Rows * IsometricBlock.Height;
            }
        }
    }
}
