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
    class Tile
    {
        //class will have info for each tile (could create seperate classes for seperate tiles)

        public enum TileType { Normal,Death,Buff,NeedBuff,Move};

        TileType type;
        /*
        Normal: Safe to walk on
        Death: You die
        Buff: Gives you a buff
        NeedBuff: You die unless you have the buff
        Move: Moves you to another space
        */
        public TileType TType//property for if other classes need to see or change tile type (such as external tool)
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public void Step()//Method to determine what happens if you step on a tile
        {
            switch (type)
            {
                case TileType.Normal:
                    break;
                case TileType.Death:
                    break;
                case TileType.Buff:
                    break;
                case TileType.NeedBuff:
                    break;
                case TileType.Move:
                    break;
            }
        }
    }
}
