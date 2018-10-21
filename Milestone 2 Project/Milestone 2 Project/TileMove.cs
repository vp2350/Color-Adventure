using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// Move tiles move the player if they are stepped on.

namespace Milestone_2_Project
{
    class TileMove : Tile
    {
        public TileMove(Rectangle rect) : base(rect)
        {

        }
    }
}
