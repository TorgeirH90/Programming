using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paratroopers_Mono
{
    class Draw
    {
        public void Drawing
            (
            ref SpriteBatch spriteBatch,
            ref Texture2D YPixel,
            ref Vector2 BakkePos,
            ref float GroundRotation,
            ref Turret turret,
            ref Texture2D TurrentUnderdel,
            ref Vector2 TurrentUnderdelRect,
            ref Vector2 TurrentMidRect,
            ref Texture2D TurrentMid,
            ref List<EnemyHelo> ChopperList,
            ref List<Bullet> BulletList,
            ref List<EnemyParatrooper> ParatrooperList
            )
        {

            //GroundPosition += 0.01f; //This makes the ground spin
            
            //Draw ground
            spriteBatch.Draw(YPixel, BakkePos, null, Color.White, GroundRotation, new Vector2(0, 0), 1, SpriteEffects.None, 1);
            
            spriteBatch.Draw(TurrentMid, TurrentMidRect, Color.White);
            spriteBatch.Draw(TurrentUnderdel, TurrentUnderdelRect, Color.White);
            

            for (int i = 0; i < ChopperList.Count; i++)
            {
                ChopperList[i].Draw(spriteBatch);
            }



            for (int i = 0; i < ParatrooperList.Count; i++)
            {
                ParatrooperList[i].Draw(spriteBatch);
            }
            for (int i = 0; i < BulletList.Count; i++)
            {
                BulletList[i].Draw(spriteBatch);
            }
            turret.Draw(spriteBatch);
        }
    }
}
