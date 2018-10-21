using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// Class will have info for each tile (could create seperate classes for seperate tiles)
namespace Milestone_2_Project
{
    class Tile:GameObject
    {

        public Tile(Rectangle rect)  :base(rect)
        {

        }

        // Check collision between this object and any given object
        public bool CheckCollision(GameObject objToCheck)
        {
            if (rect.Intersects(objToCheck.rectangle))
            {
                return true;
            }

            return false;
        }
    }
}
