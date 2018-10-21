using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// Normal tiles are safe to walk on and have no effect

namespace Milestone_2_Project
{
    class TileNormal : Tile
    {
        public TileNormal(Rectangle rect) : base(rect)
        {

        }
    }
}
