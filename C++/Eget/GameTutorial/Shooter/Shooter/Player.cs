using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    class Player
    {

        // Animation representing the player
        public Animation PlayerAnimation;

        // Position of the Player relative to the upper left side of the screen
        public Vector2 Position;

        // State of the player
        public bool Active;

        // Amount of hit points that player has
        public int Health;

        public int Weapon;
        /* 1.Bullet 
         * 2.rocket
         * 3.lazer
         * 4.OP AS FUCK weapon
         * 5.place
         * 6.hold
         * 7.er
         */

        // Get the width of the player ship
        public int Width
        {
            get { return PlayerAnimation.frameWidth; }
        }

        // Get the height of the player ship
        public int Height
        {
            get { return PlayerAnimation.frameHeigth; }
        }



        public void Initialize(Animation animation, Vector2 Initializedposition)
        {
            PlayerAnimation = animation;
            Position = Initializedposition;
            Active = true;
            Health = 1;//GUILE THEME!
            Weapon = 1;
        }

        public void Update(GameTime gametime)
        {
            PlayerAnimation.position = Position;
            PlayerAnimation.Update(gametime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            PlayerAnimation.Draw(spriteBatch);

        }

    }
}
