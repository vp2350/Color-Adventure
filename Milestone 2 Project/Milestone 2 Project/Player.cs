using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// This class will hold everything pertaining to the player position and implimentation

namespace Milestone_2_Project
{
    class Player:GameObject
    {
        // Attributes
        protected Rectangle sourceRec = new Rectangle(0, 0, 10, 10);
        protected Boolean hasBuff;

        // Readable
        public Rectangle SourceRec
        {
            get
            {
                return sourceRec;
            }
        }

        // Readable/Writeable
        public Boolean HasBuff
        {
            get
            {
                return hasBuff;
            }
            set
            {
                hasBuff = value;
            }
        }


        // Constructor
        public Player(Rectangle rect) : base(rect)
        {
            hasBuff = false;
        }

     
    }
}
