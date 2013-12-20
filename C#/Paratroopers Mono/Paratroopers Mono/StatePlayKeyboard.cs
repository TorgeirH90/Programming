using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paratroopers_Mono
{
    class StatePlayKeyboard
    {
        //Console.writeline(stuff);
       public void PlayInput
           (
               ref GameTime gameTime,
               ref TimeSpan PreviousTripTime,
               ref TimeSpan TripTime,
               ref bool trippy1,
               ref bool trippy2,
               ref Single TurretROT,
               ref Turret turret,
               ref Vector2 BulletOrigin,
               ref Vector2 BulletOriginAtZero,
               ref TimeSpan PreviousFireTime,
               ref float MoveLimit,
               ref TimeSpan FireRate,
               ref int FireContinously,
               ref Vector2 TurrentOrigin,
               ref Texture2D BulletTexture,
               ref List<Bullet> BulletList,
               ref float TurretRotAtSpace,
               ref GameState gamestate,
               ref TimeSpan PauseTimeCooldown,
               ref TimeSpan TotalPauseTime
           )
           //----------------------------------------Class Begin-----------------------------------
        {
            
            //T
            if (Keyboard.GetState().IsKeyDown(Keys.T) && (gameTime.TotalGameTime - PreviousTripTime) > TripTime && !trippy2)
            {
                if (trippy1)
                {
                    trippy1 = false;
                }
                else
                {
                    trippy1 = true;
                }
                PreviousTripTime = gameTime.TotalGameTime;
            }
            //Y
            if (Keyboard.GetState().IsKeyDown(Keys.Y) && (gameTime.TotalGameTime - PreviousTripTime) > TripTime && !trippy1)
            {
                if (trippy2)
                {
                    trippy2 = false;
                }
                else
                {
                    trippy2 = true;
                }
                PreviousTripTime = gameTime.TotalGameTime;
            }
           ////Vector calculations
           // Mouse.GetState().Y
           //     Mouse.GetState().X
                    //405, 452 location to turning point
                    //float a = (float) (Math.Atan(((Mouse.GetState().X-405)/(Mouse.GetState().Y-452)))*(180/Math.PI));
           
            //float r= sqrt(x*x+y*y);
            int x= Mouse.GetState().X-405;
            int y= Mouse.GetState().Y-452;
           
           double r = Math.Sqrt((Math.Pow(x,2)+Math.Pow(y,2)));
           float a = (float)(Math.Acos(x / r));


                    turret.Move(a);



            //Arrow left
           //Might wanna move MoveLimit to Turret.cs instead
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && (TurretROT > -MoveLimit))
            {
                turret.MoveLeft();
                TurretROT = turret.GetTurretROT();
            }
            //Arrow Right
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && (TurretROT < MoveLimit))
            {
                turret.MoveRigth();
                TurretROT = turret.GetTurretROT();

            }
            //Arrow up
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                turret.TurretZero();
                BulletOrigin = BulletOriginAtZero;
            }
            //Arrow Down
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (gameTime.TotalGameTime - PauseTimeCooldown > TimeSpan.FromSeconds(1))
                {
                    gamestate = GameState.Pause;
                    PauseTimeCooldown = gameTime.TotalGameTime;
                }
            }
            //Space
            if ((gameTime.TotalGameTime - TotalPauseTime) - PreviousFireTime > FireRate)
            {
                if ((Keyboard.GetState().IsKeyDown(Keys.Space))||Mouse.GetState().LeftButton==ButtonState.Pressed)//Obligotary SPAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACE
                {
                    
                    BulletOrigin.X = BulletOriginAtZero.X + (TurrentOrigin.Y * (float)Math.Sin(turret.GetTurretROT()));
                    //BulletOrigin.Y =  BulletOriginAtZero.Y  * (float)Math.Cos(turret.GetTurretROT());
                    BulletOrigin.Y = -2+ BulletOriginAtZero.Y - (TurrentOrigin.Y * (float)Math.Cos(turret.GetTurretROT()));
                    Console.WriteLine("degree: "+a);
        

                    TurretRotAtSpace = turret.GetTurretROT();
                    FireContinously = 1;

                    Bullet bullet = new Bullet();
                    bullet.Initialize(BulletTexture, BulletOrigin, TurretRotAtSpace);
                    BulletList.Add(bullet);
                    
                    PreviousFireTime = (gameTime.TotalGameTime - TotalPauseTime);
                }

            }

        }
       


    }
}
