

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paratroopers_Mono
{
    class EnemyHelo
    {
        public int score;
        Vector2 position;
        Vector2 paraPos;
        public bool AddEnemyParatrooper;
        bool Side;
        float speed;
        Animation HeloGraph;
        int WhenToDropTrooper;
        Rectangle Rect;
        public bool Active;
        bool DropTrooper;
        Random rand;

       

        public void Initialize(Animation HeloGraph, float Ypos, bool Side)//Side true= venstre mot høyre||Side false= høyre mot venstre
        {
            score = 100;
            Active = true;
            AddEnemyParatrooper = false;
            this.HeloGraph = HeloGraph;
            this.Side = Side;
            position.X = -40;
            position.Y=Ypos;
            rand = new Random();
            if (rand.Next(2) == 1)
            {
                WhenToDropTrooper = rand.Next(235) + 50; //For å komme til venstre for hvor det blir lagd trapp
            }
            else
            {
                WhenToDropTrooper = rand.Next(262) + 480;//For å komme til høyre
            }
            //WhenToDropTrooper = 281;
            //System.Console.WriteLine("Drop: "+WhenToDropTrooper);
            
            
            DropTrooper = true;
            speed = 4;//4
            if (!Side)
            {
                speed *= -1;
                position.X = 800;
            }

            //TrooperCoolDown = TimeSpan.FromSeconds(0.1f);
            
        }

        public void Update(GameTime gametime)
        {
            if (position.X > 850 || position.X < -50)
            {
                Active = false;
                return;
            }
            
                position.X += speed;
            
                
            HeloGraph.Position = position;
            HeloGraph.Update(gametime);

            //Can be done better
            //if ((position.X < WhenToDropTrooper + (speed + 5) && position.X > WhenToDropTrooper - (speed + 5)) && DropTrooper)
            //{
            //    AddEnemyParatrooper = true;
            //    DropTrooper = false;
            //}
            if (DropTrooper)
            {
                if (position.X > WhenToDropTrooper && (speed > 0))//Left To Right
                {
                    AddEnemyParatrooper = true;
                    DropTrooper = false;
                }
                else if (position.X < WhenToDropTrooper && (speed < 0))//Right to left or eventually standing still
                {
                    AddEnemyParatrooper = true;
                    DropTrooper = false;
                }
            }
        }

        

        public Rectangle GetRect()
        {
            Rect = new Rectangle((int)position.X, (int)position.Y, HeloGraph.frameWidth, HeloGraph.frameHeigth);
            return Rect;
        }

        public Vector2 ParaPos()
        {
            paraPos = position;
            paraPos.X += 15;
            paraPos.Y += 10;
            AddEnemyParatrooper = false;
            return paraPos;
        }


        

        public void Draw(SpriteBatch spriteBatch)
        {
            HeloGraph.Draw(spriteBatch);
        }


    }
}
