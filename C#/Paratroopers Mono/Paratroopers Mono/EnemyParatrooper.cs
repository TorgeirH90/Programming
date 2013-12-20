using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paratroopers_Mono
{
    class EnemyParatrooper
    {
        public int Trooperscore;
        public int chuteScore;
        Vector2 Position;
        Animation TrooperTexture;
        Texture2D Chutexthure;
        float fallspeed;
        float Walkspeed;
        public bool Active;
        Rectangle Rect;
        public bool gotParachute;
        Parachute Chute;

        enum ParaState { Chuted, freefall, walkleft, walkright, StandStillLeft, StandStillRight };
        ParaState parastate;
        
        public void Initialize(Animation TrooperAnimation, Texture2D ParaTexture,Vector2 Pos)
        {
            Trooperscore = 10;
            chuteScore = 20;
            gotParachute = true;
            TrooperTexture = TrooperAnimation;
            TrooperTexture.Position.X += 7;
            TrooperTexture.Position.Y += 16;
            Position=Pos;
            Walkspeed = 0.5f;
            fallspeed = 1.5f;
            Chutexthure = ParaTexture;
            Active = true;
            parastate = ParaState.Chuted;
            Chute = new Parachute();
            Chute.initialize(ParaTexture, Pos);

        }
        



        public Vector2 Update(GameTime gametime, Vector2 TroopersAtTurret)
        {//Left and Right is the number of paratroopers on each side of the turret



            switch (parastate)
            {
               case ParaState.Chuted :
                    Position.Y += fallspeed;
                    Chute.position.Y = Position.Y;
                    if (Position.Y >= 440)
                    {
                        Position.Y = 440;
                        if (Position.X<400)
                        {
                            parastate = ParaState.walkright;
                        }
                        else
                        {
                            parastate = ParaState.walkleft;
                        }
                        gotParachute = false;
                        
                    }
                   break;
               case ParaState.freefall : 

                  Position.Y += fallspeed;
                     if (Position.Y >= 441)
                     {
                         Active = false;
                     }
                   break;
               case ParaState.walkleft : 
                   Position.X -= Walkspeed;
                    //Hard variable for turret, change if turret width changes
                   if (Position.X <= 440 && TroopersAtTurret.Y == 0)
                    {
                        Position.X = 440;
                        parastate = ParaState.StandStillLeft;
                            
                        TroopersAtTurret.Y++;
                    }
                    else if (Position.X <= 458 && TroopersAtTurret.Y == 1)
                   {
                       Position.X = 458;
                       parastate = ParaState.StandStillLeft;
                       TroopersAtTurret.Y++;
                   }
                   else if (Position.X <= 476 && TroopersAtTurret.Y == 2)
                   {
                       Position.Y -= 18;
                       Position.X = 440;
                       parastate = ParaState.StandStillLeft;
                       TroopersAtTurret.Y++;
                   }
                   else if (Position.X <= 476 && TroopersAtTurret.Y == 3)
                   {
                       Position.Y -= 18;
                       Position.X = 458;
                       parastate = ParaState.StandStillLeft;
                       TroopersAtTurret.Y++;
                   }
                   else if (Position.X <= 476 && TroopersAtTurret.Y == 4)
                   {
                       
                       Position.X = 476;
                       parastate = ParaState.StandStillLeft;
                       TroopersAtTurret.Y++;
                   }
                    else if (Position.X <= 494 && TroopersAtTurret.Y == 5)
                   {
                       Position.Y -= 36;
                       Position.X = 440;
                       parastate = ParaState.StandStillLeft;
                       TroopersAtTurret.Y++;
                   }
                    else if ((Position.X <= 494 && TroopersAtTurret.Y >= 6) && Position.Y == 440)
                   {
                       Position.Y -= 50;
                       Position.X = 440;
                       TroopersAtTurret.Y++;

                       
                   }
                   if (Position.X > 365 && Position.X < 415&&TroopersAtTurret.Y>6)
                   {
                       
                       TroopersAtTurret.Y = -1337;
                   }
                   break;


               case ParaState.walkright : 
                    Position.X += Walkspeed;

                    if (Position.X >= 342 && TroopersAtTurret.X == 0)
                        {
                            Position.X = 342;
                            parastate = ParaState.StandStillLeft;
                            
                            TroopersAtTurret.X++;
                        }
                    else if (Position.X >= 324 && TroopersAtTurret.X == 1)
                   {
                       Position.X = 324;
                       parastate = ParaState.StandStillLeft;
                       TroopersAtTurret.X++;
                   }
                   else if (Position.X >= 306 && TroopersAtTurret.X == 2)
                   {
                       Position.Y -= 18;
                       Position.X = 342;
                       parastate = ParaState.StandStillLeft;
                       TroopersAtTurret.X++;
                   }
                   else if (Position.X >= 306 && TroopersAtTurret.X == 3)
                   {
                       Position.Y -= 18;
                       Position.X = 324;
                       parastate = ParaState.StandStillLeft;
                       TroopersAtTurret.X++;
                   }
                   else if (Position.X >= 306 && TroopersAtTurret.X == 4)
                   {
                       
                       Position.X = 306;
                       parastate = ParaState.StandStillLeft;
                       TroopersAtTurret.X++;
                   }
                   else if (Position.X >= 288 && TroopersAtTurret.X == 5)
                   {
                       Position.Y -= 36;
                       Position.X = 342;
                       parastate = ParaState.StandStillLeft;
                       TroopersAtTurret.X++;
                   }
                   else if ((Position.X >= 288 && TroopersAtTurret.X >= 6)&&Position.Y==440)
                   {
                       Position.Y -= 50;
                       Position.X = 342;
                       TroopersAtTurret.X++;
                       
                   }
                   if (Position.X > 365 && Position.X < 405&&TroopersAtTurret.X>6)
                   {

                       TroopersAtTurret.X = -1337;
                   }

                    
                   break;
                case ParaState.StandStillLeft:
                   

                   break;
                case ParaState.StandStillRight:
                   break;




                   

            }

            TrooperTexture.Position = Position;
            TrooperTexture.Position.X += 7;
            TrooperTexture.Position.Y += 16;
            TrooperTexture.UpdateNotChangeFrame(gametime);
            return TroopersAtTurret;



        }

        public void Draw(SpriteBatch spritebatch)
        {
            if (gotParachute)
            {
                Chute.Draw(spritebatch);
            }
            TrooperTexture.Draw(spritebatch);
            
        }

        public float GetFallSpeed()
        {
            return fallspeed;
        }

        public Rectangle GetRect()
        {
                Rect = new Rectangle((int)TrooperTexture.Position.X, (int)TrooperTexture.Position.Y, TrooperTexture.frameWidth, TrooperTexture.frameHeigth);
           
            return Rect;
        }

        public Rectangle GetChuteRect()
        {
            Rect = new Rectangle((int)Chute.position.X, (int)Chute.position.Y, Chutexthure.Width, Chutexthure.Height);
            
            return Rect;
        }

        public void LoseParachute()
        {
            parastate = ParaState.freefall;
            Trooperscore = 50;
            gotParachute = false;
            fallspeed = 5.0f;
            TrooperTexture.ChangeFrame();
        }


    }
}
