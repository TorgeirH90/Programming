using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Paratroopers_Mono
{
    class Spawner
    {
        public void Spawning
            (
                ref GameTime gameTime,
                ref TimeSpan PreviousEnemyTime,
                ref TimeSpan EnemyRate,
                ref List<EnemyHelo> ChopperList,
                ref Random rnd,
                ref Texture2D EnemyTexture,
                ref Texture2D EnemyTexture2,
                ref Texture2D ParatrooperTexture,
                ref Texture2D ParachuteTexture,
                ref List<EnemyParatrooper> ParatrooperList,
                ref TimeSpan TotalPauseTime
            )
        {
            if ((gameTime.TotalGameTime - TotalPauseTime) - (PreviousEnemyTime - TotalPauseTime) > EnemyRate)
            {
                //Console.WriteLine("GT: "+gameTime.TotalGameTime);
                //Console.WriteLine("TPT: " + (TotalPauseTime));
                //Console.WriteLine("GT-TPT: " + (gameTime.TotalGameTime - TotalPauseTime));
                //Console.WriteLine("PET:" + PreviousEnemyTime);
                AddEnemyHelo
                    (
                        ref  rnd,
                        ref  EnemyTexture,
                        ref  EnemyTexture2,
                        ref  ChopperList
                    );

                PreviousEnemyTime = gameTime.TotalGameTime;
            }

            for (int i = 0; i < ChopperList.Count; i++)
            {
                if (ChopperList[i].AddEnemyParatrooper)
                {
                    //Console.WriteLine("Sup?");
                    AddEnemyParatrooper
                        (
                            ChopperList[i].ParaPos(),
                            ref  ParatrooperTexture,
                            ref  ParachuteTexture,
                            ref  ParatrooperList
                        );
                }
            }

        }

        private void AddEnemyHelo
            (
                ref Random rnd,
                ref Texture2D EnemyTexture,
                ref Texture2D EnemyTexture2,
                ref List<EnemyHelo> ChopperList
            )
        {

            //LeftOrRigth = lastHeloDirection;
            int LeftOrRigth = rnd.Next(2);


            if (LeftOrRigth == 0)
            {

                int yPos = 10;
                Animation enemyAnim = new Animation();
                enemyAnim.Initialize(EnemyTexture, new Vector2(0, yPos), EnemyTexture.Width / 2, EnemyTexture.Height, 2, 80, Color.White, true);

                EnemyHelo Helo = new EnemyHelo();
                Helo.Initialize(enemyAnim, yPos, false);
                ChopperList.Add(Helo);
            }
            else
            {
                int yPos = 50;
                Animation enemyAnim = new Animation();
                enemyAnim.Initialize(EnemyTexture2, new Vector2(0, yPos), EnemyTexture.Width / 2, EnemyTexture.Height, 2, 80, Color.White, true);

                EnemyHelo Helo = new EnemyHelo();
                Helo.Initialize(enemyAnim, yPos, true);
                ChopperList.Add(Helo);
            }


        }
        private void AddEnemyParatrooper
            (
                Vector2 Position,
                ref Texture2D ParatrooperTexture,
                ref Texture2D ParachuteTexture,
                ref List<EnemyParatrooper> ParatrooperList
            )
            {
                EnemyParatrooper para = new EnemyParatrooper();
                Animation TrooperAnim = new Animation();
                TrooperAnim.Initialize(ParatrooperTexture, Position, ParatrooperTexture.Width / 2, ParatrooperTexture.Height, 2, 80, Color.White, true);
                para.Initialize(TrooperAnim, ParachuteTexture, Position);
                ParatrooperList.Add(para);
            }


    }
}
