using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Paratroopers_Mono
{
    class SpecialFeatures
    {

        public void LineMovement
            (
            ref bool Retract,
            ref float LineMovement
            )
        {
            if (Retract)
            {
                LineMovement += 0.4f;
                if (LineMovement > 1)
                {
                    Retract = false;
                }
            }
            else
            {
                LineMovement -= 0.4f;
                if (LineMovement < -1)
                {
                    Retract = true;
                }
            }


        }

        public void DrawExtraLines
            (
                ref bool trippy1,
                ref bool trippy2,
                ref SpriteBatch spriteBatch,
                ref Texture2D YPixel,
                ref Turret turret,
                ref int insideoutside,
                ref float LineMovement

            )
        {

            if (trippy1)
            {
                for (int i = -50; i < 130; i++)
                {
                    spriteBatch.Draw(YPixel, new Rectangle(i * 10, 0, 1, 600), null, Color.White);
                    spriteBatch.Draw(YPixel, new Rectangle(i * 10, 0, 1, 900), null, Color.White, turret.GetTurretROT() * 1.1f, new Vector2(0, 0), SpriteEffects.None, 1);
                    spriteBatch.Draw(YPixel, new Rectangle(i * 10, 0, 1, 900), null, Color.White, -turret.GetTurretROT() * 1.1f, new Vector2(0, 0), SpriteEffects.None, 1);
                }
            }
            else if (trippy2)
            {
                insideoutside = (int)(LineMovement);
                for (int i = -50; i < 130; i++)
                {
                    insideoutside *= -1;
                    spriteBatch.Draw(YPixel, new Rectangle((i * 10) + insideoutside, 0, 1, 600), null, Color.White);
                }
            }
        }



    }
}
