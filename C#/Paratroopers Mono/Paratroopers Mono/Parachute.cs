using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paratroopers_Mono
{
    class Parachute
    {
        Texture2D Chutexture;
        
        public Vector2 position;
        
        public bool Pactive;

        public void initialize(Texture2D Texture,Vector2 Pos)
        {
            Pactive = true;
            Chutexture = Texture;
            
            
            position = Pos;
        }

        public void Update(GameTime gameTime, Vector2 Pos)
        {
            position.X = Pos.X;
            position.Y = Pos.Y;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Chutexture, position, Color.White);

        }
        



    }
}
