using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// Kill tiles will kill you instantly if you step on them

namespace Milestone_2_Project
{
    class TileKill : Tile
    {
        public TileKill(Rectangle rect) : base(rect)
        {

        }
    }
}
