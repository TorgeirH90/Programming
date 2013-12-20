using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paratroopers_Mono
{
    class Turret
    {
        Texture2D TurretPic;
        Vector2 TurrentOrigin;
        Rectangle TurrentRect;
        float TurretROT;
        float RotationSpeed;
        float MoveLimit;
        public void Initialize(Texture2D HeloGraph, Vector2 TurrOrig, float MoveLimit)
        {
            this.MoveLimit = MoveLimit;
            TurretPic = HeloGraph;
            RotationSpeed = ((float)Math.PI / 180) * 3.70f;//Radianer
            TurrentOrigin = TurrOrig;//
            TurrentRect = new Rectangle(400, 427, 10, 25);//Plassering og størrelse
        }
        public void MoveLeft()
        {
            TurretROT = TurretROT - RotationSpeed;
            
        }

        public void MoveRigth()
        {
            TurretROT = TurretROT + RotationSpeed;
        }
        //Used when mouse is in the play
        public void Move(float toMouseRot)
        {
            //Move limit = ((float)(Math.PI / 180));
            //TurretROT = -(toMouseRot+90);
            TurretROT = -toMouseRot+(float)(Math.PI/2);
            if (TurretROT > MoveLimit)
            {
                TurretROT = MoveLimit;
            }
            else if (TurretROT < -MoveLimit)
            {
                TurretROT = -MoveLimit;
            }

        }


        public void Update(GameTime gametime)
        {
            

        }






        public float GetTurretROT()
        {
            return TurretROT;
        }
        public void TurretZero()
        {
            TurretROT = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TurretPic, TurrentRect, null, Color.White, TurretROT, TurrentOrigin, SpriteEffects.None, 1);
        }


    }
}
 