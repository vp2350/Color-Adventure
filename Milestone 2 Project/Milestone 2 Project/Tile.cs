using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Milestone_2_Project
{
    class Tile:GameObject
    {
        //class will have info for each tile (could create seperate classes for seperate tiles)
        private Rectangle pos;
        public Tile(int x, int y, int width, int height)             //Main constructor
            :base(x,y,width,height)
        {
            position = new Rectangle(x, y, width, height);
        }
            public bool CheckCollision(GameObject objToCheck)
        {
            //check collision between this object and any given object
            if (pos.Intersects(objToCheck.Position))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
