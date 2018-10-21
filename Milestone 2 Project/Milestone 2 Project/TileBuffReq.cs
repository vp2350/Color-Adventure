using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// Buff Required tiles require the player to have an active buff, else they will be killed

namespace Milestone_2_Project
{
    class TileBuffReq : Tile
    {
        public TileBuffReq(Rectangle rect) : base(rect)
        {

        }
    }
}
