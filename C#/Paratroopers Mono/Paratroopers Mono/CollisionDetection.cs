using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace Paratroopers_Mono
{
    class CollisionDetection
    {

        public void Collision
            (
            ref List<Bullet> BulletList,
            ref List<EnemyHelo> ChopperList,
            ref List<EnemyParatrooper> ParatrooperList,
            ref int Score,
            ref TimeSpan EnemyRate
            )
        {

            Rectangle BulletRect = new Rectangle();
            Rectangle EnemyRect = new Rectangle();
            Rectangle EnemyRect2 = new Rectangle();

            for (int i = 0; i < BulletList.Count(); i++)
            {
                BulletRect = BulletList[i].GetRect();

                for (int j = 0; j < ChopperList.Count(); j++)
                {
                    EnemyRect = ChopperList[j].GetRect();

                    if (BulletRect.Intersects(EnemyRect))
                    {
                        ChopperList[j].Active = false;
                        BulletList[i].Active = false;
                        Score += ChopperList[j].score;
                        if (EnemyRate.TotalMilliseconds > 1000)
                        {
                            EnemyRate = TimeSpan.FromMilliseconds((EnemyRate.TotalMilliseconds * 0.99));
                        }
                    }
                    if (!ChopperList[j].Active)
                    {
                        ChopperList.RemoveAt(j);
                    }

                }
                for (int j = 0; j < ParatrooperList.Count(); j++)
                {
                    EnemyRect = ParatrooperList[j].GetRect();
                    EnemyRect2 = ParatrooperList[j].GetChuteRect();

                    if (BulletRect.Intersects(EnemyRect))
                    {
                        ParatrooperList[j].Active = false;
                        BulletList[i].Active = false;
                        Score += ParatrooperList[j].Trooperscore;
                    }
                    if (ParatrooperList[j].gotParachute)
                    {
                        if (BulletRect.Intersects(EnemyRect2))//Chute down
                        {
                            ParatrooperList[j].LoseParachute();
                            Score += ParatrooperList[j].chuteScore;
                        }
                    }
                    if (!ParatrooperList[j].Active)
                    {
                        ParatrooperList.RemoveAt(j);
                        if (EnemyRate.TotalMilliseconds > 1000)
                        {//This makes things interesting, and challenging
                            EnemyRate = TimeSpan.FromMilliseconds((EnemyRate.TotalMilliseconds * 0.99));
                        }
                    }
                }

                if (!BulletList[i].Active)
                {
                    BulletList.RemoveAt(i);
                }

            }
        }
    }
}
