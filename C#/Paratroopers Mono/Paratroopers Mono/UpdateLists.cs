using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Paratroopers_Mono
{
    class UpdateLists
    {

        public void Update
            (
            ref List<Bullet> BulletList,
            ref GameTime gameTime,
            ref List<EnemyParatrooper> ParatrooperList,
            ref Vector2 AmountOfTroopersOnTurret,
            ref Vector2 TimePassed,
            ref GameState gamestate,
            ref SaveAndLoadGame Sally,
            ref int Score,
            ref TimeSpan TotalPauseTime,
            ref List<EnemyHelo> ChopperList

            )
        {
            
            for (int i = 0; i < BulletList.Count; i++)
            {
                BulletList[i].Update(gameTime);
            }
            for (int i = 0; i < ParatrooperList.Count; i++)
            {
                AmountOfTroopersOnTurret = ParatrooperList[i].Update(gameTime, AmountOfTroopersOnTurret);
                if (AmountOfTroopersOnTurret.X == (-1337) || AmountOfTroopersOnTurret.Y == (-1337))
                {
                    TimePassed = new Vector2((gameTime.TotalGameTime - TotalPauseTime).Minutes, (gameTime.TotalGameTime - TotalPauseTime).Seconds);
                    gamestate = GameState.SetScore;
                    
                }
            }

            for (int i = 0; i < ChopperList.Count; i++)
            {
                ChopperList[i].Update(gameTime);
            }
        }
    }
}
