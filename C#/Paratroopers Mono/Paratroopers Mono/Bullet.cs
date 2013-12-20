using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Paratroopers_Mono
{
    class Bullet
    {
        Vector2 BulletPos;
        Texture2D BulletGraphic;
        
        float BulletSpeed;
        float TotalX;
        double AngleInDeg;
        double AngleInTan;
        float angle;
        float Yangle;
        float Xangle;
        public bool Active;


        Rectangle Rect;
        public Rectangle GetRect()
        {
            Rect = new Rectangle((int)BulletPos.X, (int)BulletPos.Y, BulletGraphic.Width, BulletGraphic.Height);
            return Rect;
        }
        
        public void Initialize(Texture2D Graphics, Vector2 POS, float Angle)
        {
            Active = true;
            BulletGraphic = Graphics;
            BulletPos = POS;
            BulletSpeed = 15;//15

            AngleInDeg = MathHelper.ToDegrees(Angle);
            AngleInTan = Math.Tan(Angle);

            angle = Angle-(float)Math.PI/2;
            //Goodie :D
            Yangle = (float)Math.Sin((double)angle);
            Xangle = (float)Math.Cos((double)angle);
            
            TotalX = POS.X;
            

        }

        public void Update(GameTime gametime)
        {
            //BulletPos.Y -= BulletSpeedY;

            //BulletPos.X += (float)AngleInTan*4.91f;
            //Vectors...OFCOURSE!
            BulletPos.Y += Yangle * BulletSpeed;//j
            BulletPos.X += Xangle * BulletSpeed;//i
                                                                        //Would've used k if 3d
            

            if (BulletPos.X > 1000 || BulletPos.X < -1000)
            {
                Active = false;
            }
            if (BulletPos.Y > 1000 || BulletPos.Y < -1000)
            {
                Active = false;
            }
            
        }

        public void Draw(SpriteBatch spritebatch)
        {
            //spritebatch.Draw(BulletGraphic, BulletPos, Color.White);
            spritebatch.Draw(BulletGraphic, new Rectangle((int)BulletPos.X, (int)BulletPos.Y, (int)BulletGraphic.Width, (int)BulletGraphic.Height), null, Color.White, 0, new Vector2(0, 0), SpriteEffects.None, 0); 
            


        }
    }
}
