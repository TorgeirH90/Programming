using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace KSCW.MainClasses
{
    class LoadContent
    {
        SpriteBatch spriteBatch;
        private GlobalValues G;
        GraphicsDevice DeviceG;


        public LoadContent(GlobalValues G)
        {
            // TODO: Complete member initialization
            this.G = G;
            
        }

        public void Load(ref SpriteBatch SB, GraphicsDevice DeviceG)
        {
            spriteBatch = SB;
            //G.Utedo = Texture2D.FromStream(DeviceG, TitleContainer.OpenStream("Content/utedo_map")); 
            G.Utedo=LoadImage(DeviceG,"Content/utedo_map.jpg");

        }

        private Texture2D LoadImage(GraphicsDevice DeviceG, string Path)
        {
            return Texture2D.FromStream(DeviceG, TitleContainer.OpenStream(Path));
        }
    }
}
