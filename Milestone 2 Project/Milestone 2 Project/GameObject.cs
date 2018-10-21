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
        protected Rectangle position;                           //Main rectangle for the game object
        protected Texture2D sprite;

        public Rectangle Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }
        public int PositionX
        {
            get
            {
                return position.X;
            }
            set
            {
                position.X = value;
            }
        }
        public int PositionY
        {
            get
            {
                return position.Y;
            }
            set
            {
                position.Y = value;
            }
        }
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

        public GameObject(int x, int y, int width, int height)          //Main constructor for game object
        {
            position = new Rectangle(x, y, width, height);
        }
        public virtual void Draw(SpriteBatch spriteBatch)               //Overridable draw method
        {
            spriteBatch.Draw(sprite, position, Color.White);
        }
    }
}
