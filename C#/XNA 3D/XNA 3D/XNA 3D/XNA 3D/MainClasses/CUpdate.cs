using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace XNA_3D.MainClasses
{
    class Update
    {
        private GlobalValues G;



        public Update(GlobalValues G)
        {
            // TODO: Complete member initialization
            this.G = G;
        }

        public void Updating(GameTime GT)
        {
            for (int i = 0; i < G.Bullets.Count; i++)
            {
                if (!G.Bullets[i].Update(G.ship.Position))
                {
                    G.Bullets.RemoveAt(i);
                }
            }
            

            if (Keyboard.GetState().IsKeyDown(Keys.A))//&&(G.ship.Yrot<G.MaxYTurn))
            {
                G.ship.TurnLeft(true);
                    //Yrot += G.YTurn;
                //G.SideRightBullpos.Y += G.YTurn;
                //G.SideLeftBullpos.Y += G.YTurn;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D)) //&& (G.ship.Yrot > -G.MaxYTurn))
            {
                G.ship.TurnLeft(false);
                //G.ship.Yrot -= G.YTurn;
                //G.SideRightBullpos.Y -= G.YTurn;
                //G.SideLeftBullpos.Y -= G.YTurn;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                //G.ship.Position.Z += (float)(Math.Cos(G.ship.Yrot) * G.ship.speed);
                //G.ship.Position.X += (float)(Math.Sin(G.ship.Yrot) * G.ship.speed);
                G.ship.NoseDown(false);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {

                G.ship.NoseDown(true);
                
            }
            //G.ship.Position.Z -= (float)(Math.Cos(G.ship.Yrot) * G.ship.speed);
            //G.ship.Position.X -= (float)(Math.Sin(G.ship.Yrot) * G.ship.speed);
            //G.ship.Direction.X = G.ship.speed;
            //Console.WriteLine("Cos: " + (float)(Math.Cos(G.ship.Yrot) * 100));
            //Console.WriteLine("Sin: " + (float)(Math.Sin(G.ship.Yrot) * 100));
            if (Keyboard.GetState().IsKeyDown(Keys.NumPad8))
            {
                G.ship.Position.Y += 10;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.NumPad5))
            {
                G.ship.Position.Y -= 10;
            }
            
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                G.ship.BankLeft(true);

                //G.SideLeftBullpos.Y += 0.1f;
                //G.SideRightBullpos.Y += 0.1f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {

                G.ship.BankLeft(false);
                //G.SideLeftBullpos.Y -= 0.1f;
                //G.SideRightBullpos.Y -= 0.1f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                //Create bullet
                //Put in list
                //G.Bullpos.X = G.ship.Position.X + G.FrontBullpos.X;
                //G.Bullpos.Z = G.ship.Position.Z + G.FrontBullpos.Z;
                //Vector3 FrontShoothole = new Vector3(((float)Math.Sin(G.ship.Yrot) * G.FrontBullpos.Z) + G.Bullpos.X, G.Bullpos.Y, (float)Math.Cos(G.ship.Yrot) * G.FrontBullpos.Z + G.ship.Position.Z);
                //Objects.Sphere FrontBullet = new Objects.Sphere(G.BulletModel, G.ship.Yrot, FrontShoothole);
                //FrontBullet.Model = G.BulletModel;
                //G.Bullets.Add(FrontBullet);


                //G.Bullpos.X = G.ship.Position.X + G.SideLeftBullpos.X;
                //G.Bullpos.Z = G.ship.Position.Z + G.SideLeftBullpos.Z;
                
                
                //float Lrotat = G.ship.Yrot + MathHelper.ToRadians(101);
                
                //Vector3 LeftShoothole = new Vector3(
                //    ((float)Math.Sin(Lrotat) * G.SideLeftBullpos.Z) + G.Bullpos.X,          //X
                //    G.SideLeftBullpos.Y,                                                    //Y
                //    (float)Math.Cos(Lrotat) * G.SideLeftBullpos.Z + G.ship.Position.Z);     //Z
                //Left
                //X: -870 Y: 0,32 Z: 1,739999
                

                Objects.Sphere LeftBullet = new Objects.Sphere(
                    G.BulletModel, 
                    G.ship.Yrot,
                    G.Tools.SphereToChartesian(G.SideLeftBullpos)+G.ship.Position);

                G.Bullets.Add(LeftBullet);


                //X: -780 Y: -0,36 Z: -1,779999
                //Console.Clear();

                //Console.WriteLine("SphereCoord:\n Length:" + G.SideLeftBullpos.X
                //    + "\n XZrot: " + G.SideLeftBullpos.Y
                //    + "\n Yrot: " + G.SideLeftBullpos.Z
                //    );

                //Console.WriteLine("PositionCoord: \n X: " + G.Tools.SphereToChartesian(G.SideLeftBullpos).X
                //    + "\n Y: " + G.Tools.SphereToChartesian(G.SideLeftBullpos).Y
                //    + "\n Z: " + G.Tools.SphereToChartesian(G.SideLeftBullpos).Z
                //    );

                //Console.WriteLine("ShipPositionCoord: \n X: " + G.Tools.SphereToChartesian(G.SideRightBullpos).X
                // + "\n Y: " + G.Tools.SphereToChartesian(G.SideRightBullpos).Y
                // + "\n Z: " + G.Tools.SphereToChartesian(G.SideRightBullpos).Z
                // );

                
                Objects.Sphere RightBullet = new Objects.Sphere(
                    G.BulletModel,
                    G.ship.Yrot,
                    G.Tools.SphereToChartesian(G.SideRightBullpos)+G.ship.Position);

                G.Bullets.Add(RightBullet);



                //Objects.Sphere spore = new Objects.Sphere(
                //    G.BulletModel, 
                //    G.ship.Yrot, 
                //    G.Tools.SphereToChartesian(G.SideLeftBullpos));

                //G.Bullets.Add(spore);

                //Right
                //X: -780 Y: -0,36 Z: -1,779999

                //Left
                //X: -870 Y: 0,32 Z: 1,739999

            }
            Console.Clear();

            Console.WriteLine("SphereCoord:\n Length:" + G.SideLeftBullpos.X
                + "\n XZrot: " + G.SideLeftBullpos.Y
                + "\n Yrot: " + G.SideLeftBullpos.Z
                );

            Console.WriteLine("PositionCoord: \n X: " + G.Tools.SphereToChartesian(G.SideLeftBullpos).X
                + "\n Y: " + G.Tools.SphereToChartesian(G.SideLeftBullpos).Y
                + "\n Z: " + G.Tools.SphereToChartesian(G.SideLeftBullpos).Z
                );
            //G.ball.Position.X = G.Spherelocation.X * ((float)Math.Cos(G.Spherelocation.Y)) * ((float)Math.Sin(G.Spherelocation.Z));

            //G.ball.Position.Y = G.Spherelocation.X * ((float)Math.Sin(G.Spherelocation.Y)) * ((float)Math.Sin(G.Spherelocation.Z));

            //G.ball.Position.Z = G.Spherelocation.X * ((float)Math.Cos(G.Spherelocation.Z));


            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift)&&!(G.Speeding||G.Speedup||G.SpeedDown))//Double negative, Fuck yeah!
            {
                G.Speedup = true;
                G.ship.Speedup();
                
            }
            //Console.Write("Up: " + G.Speedup + " Down: " + G.SpeedDown+" fov: "+G.Fov);
            //Console.WriteLine(" ||diff: " + (GT.TotalGameTime.TotalSeconds - G.SpeedOnOffTimer.TotalSeconds));
            
            if (G.Speedup && G.Fov < G.speedFov)//(G.SpeedOnOffTimer.Seconds - GT.TotalGameTime.Seconds) < 1)
            {
                G.Fov+=1;
                if (G.Fov >= G.speedFov)
                {
                    G.Fov = G.speedFov;
                    G.SpeedOnOffTimer = GT.TotalGameTime;
                    G.Speedup = false;
                    G.Speeding = true;
                }
            }

            else if ((GT.TotalGameTime.TotalSeconds - G.SpeedOnOffTimer.TotalSeconds) < 5)
            {
                G.SpeedDown = true;
                G.Speeding = false;
                
            }
            else if (G.SpeedDown)
            {
                G.Fov -= 1;
                if (G.Fov <= 47)
                {
                    G.Fov = G.stdfov;
                    G.SpeedDown = false;
                    G.ship.SpeedDown();
                }
            }

            //Camera
            if (Keyboard.GetState().IsKeyDown(Keys.RightControl))
            {
                //G.CamPos.X = (float)(Math.Cos(G.CamRot) * G.Zoom);
                //G.CamPos.Z = (float)(Math.Sin(G.CamRot) * G.Zoom);
                G.CamRot += 0.01f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.NumPad0))
            {
                //G.CamPos.X = (float)(Math.Cos(G.CamRot) * G.Zoom);
                //G.CamPos.Z = (float)(Math.Sin(G.CamRot) * G.Zoom);
                G.CamRot -= 0.01f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Home))
            {
                G.ship.Position.X -= 5;
                G.CamPos.X -= 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.End))
            {
                G.ship.Position.X += 5;
                G.CamPos.X += 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.PageUp))
            {
                G.SideLeftBullpos.X += 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.PageDown))
            {
                G.SideLeftBullpos.X -= 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                G.SideLeftBullpos.Z += 0.01f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                G.SideLeftBullpos.Z -= 0.01f;
                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                G.ball.Position.X-= 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                G.ball.Position.X += 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.NumPad4))
            {
                G.ball.Position.Y += 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.NumPad1))
            {
                G.ball.Position.Y -= 5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                G.Spherelocation.X = 0;
                G.Spherelocation.Y = 0;
                G.Spherelocation.Z = 0;
                G.ship.Reset();
                G.Bullets.Clear();
            }


            if (Keyboard.GetState().IsKeyDown(Keys.U))
            {
                G.ship.scale += .1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.I))
            {
                G.ship.scale -= .1f;
            }

            //Console.WriteLine("X: " + G.Spherelocation.X + " Y: " + G.Spherelocation.Y + " Z: " + G.Spherelocation.Z);

            //Console.WriteLine("X: " + G.Bullpos.X+" Y: " + G.Bullpos.Y + " Z: " + G.Bullpos.Z);
            if (Keyboard.GetState().IsKeyDown(Keys.OemPlus) && (!G.drawlingekeydown1))
            {
                G.Straw.reSize(0.1);
                //if (G.drawLines < G.MaxDrawlines)
                //{
                //    G.drawLines++;
                //}
                G.drawlingekeydown1 = true;
            }
            else if (!Keyboard.GetState().IsKeyDown(Keys.OemPlus))
            {
                G.drawlingekeydown1 = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.OemMinus) && (!G.drawlingekeydown2))
            {
                G.Straw.reSize(-0.1);
                //if (G.drawLines > 1)
                //{
                //    G.drawLines--;
                //}
                G.drawlingekeydown2 = true;
            }
            else if (!Keyboard.GetState().IsKeyDown(Keys.OemMinus))
            {
                G.drawlingekeydown2 = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.B)&&(G.Zoom>501))//In
            {
                G.Zoom -= 100;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.N))//Out
            {
                G.Zoom += 100;
            }




            //Console.Write("Check: ");
            //Collision
            for (int j = 0; j < G.Bullets.Count; j++)
            {
                Vector4 BS = G.Bullets[j].Collision();
                for (int i = 0; i < G.Cubes.Count; i++)
                {
                    if (G.Cubes[i].Position.Z + 100500 < G.ship.Position.Z)
                    {
                        G.Cubes.RemoveAt(i);
                    }
                    else
                    {
                        Vector4 BB = G.Cubes[i].Collisionbs();
                        Vector3 Vectorsum = new Vector3(BS.X - BB.X, BS.Y - BB.Y, BS.Z - BB.Z);//S 12 Gul bok
                        double distance = Math.Abs((Math.Sqrt(Math.Pow(Vectorsum.X, 2) + Math.Pow(Vectorsum.Y, 2) + Math.Pow(Vectorsum.Z, 2))));

                        if (distance < Math.Abs(BB.W + BS.W))
                        {
                            //Console.WriteLine("!!CRASH!!");
                            G.Cubes.RemoveAt(i);
                        }
                        else
                        {

                            //Console.WriteLine("Sphere: " + BS.Center);
                            //Console.WriteLine("Cube max: " + BB.Max + " Cube min: "+ BB.Min);
                        }
                    }
                }
            }
            //End collision

            //Add more cubes
            //Use a class to spawn them in

            //Cam
            if (true)
            {


                G.CamPos.X = (float)(Math.Cos(G.CamRot) * G.Zoom);
                G.CamPos.Z = (float)(Math.Sin(G.CamRot) * G.Zoom) + G.ship.Position.Z;
                //G.CamPos.Y = G.ship.Position.Y + 5000;
            }
            else
            {
                G.CamPos.X = G.ship.Position.X + (float)(Math.Cos(-G.ship.Yrot+(Math.PI/2)) * (10000));
                G.CamPos.Z = G.ship.Position.Z + (float)(Math.Sin(-G.ship.Yrot + (Math.PI / 2)) * (10000));

                G.CamPos.Y = G.ship.Position.Y + 5000;
            }
        }//End update
    }
}
