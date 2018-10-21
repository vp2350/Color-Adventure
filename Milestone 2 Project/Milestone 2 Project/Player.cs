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
    class Player:GameObject
    {
        //this class will hold everything partaining to the player position and implimentation
        //attributes
        Texture2D texture2D;
        Rectangle rectangle;

        //properties
        public Texture2D Texture2D
        {
            get
            {
                return this.texture2D;
            }
            set
            {
                this.texture2D = value;
            }
        }
        public Rectangle Rectangle
        {
            get
            {
                return this.rectangle;
            }
            set
            {
                this.rectangle = value;
            }
        }

        //constructor
        public Player(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            rectangle = new Rectangle(x, y, width, height);
        }
    }
}
