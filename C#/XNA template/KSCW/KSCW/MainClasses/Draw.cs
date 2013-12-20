using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KSCW.MainClasses
{
    class Draw
    {
        private GlobalValues G;



        public Draw(GlobalValues G)
        {
            // TODO: Complete member initialization
            this.G = G;
        }

        public void Drawing(GameTime gameTime, ref SpriteBatch SB)
        {
            SB.Draw(G.Utedo, G.CastleLocation, Color.White);
        }
    }
}
