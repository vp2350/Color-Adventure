using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Milestone_2_Project
{
    class GameObject
    {
        protected Rectangle rect;                           //Main rectangle for the game object
        protected Texture2D sprite;

        // Readable/Writeable
        public Rectangle rectangle
        {
            get
            {
                return rect;
            }
            set
            {
                rect = value;
            }
        }

        // Readable/Writeable
        public int PositionX
        {
            get
            {
                return rect.X;
            }
            set
            {
                rect.X = value;
            }
        }

        // Readable/Writeable
        public int PositionY
        {
            get
            {
                return rect.Y;
            }
            set
            {
                rect.Y = value;
            }
        }

        // Readable/Writeable
        public Texture2D Sprite
        {
            get
            {
                return sprite;
            }
            set
            {
                sprite = value;
            }
        }


        public GameObject(Rectangle rect)          //Main constructor for game object
        {
            this.rect = rect;
        }

        public virtual void Draw(SpriteBatch spriteBatch)               //Overridable draw method
        {
            spriteBatch.Draw(sprite, rect, Color.White);
        }
    }
}
