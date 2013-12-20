using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Paratroopers_Mono
{
    class TextOnScreen
    {
        Vector2 SurvivedPlacement = new Vector2(25, 100);
        string minutes;
        string seconds;
        public void text
            (
            ref GameState gamestate,
            ref Vector2 TimePassed,
            ref SpriteBatch spriteBatch,
            ref SpriteFont font,
            ref int Score,
            ref GameTime gameTime,
            ref SaveAndLoadGame Sally,
            ref TimeSpan TotalPauseTime,
            ref TimeSpan EnemyRate

            )
        {
            //new vetor(400,475)
            spriteBatch.DrawString(font, "E.R.:" + EnemyRate, new Vector2(200, 470), Color.White);
            spriteBatch.DrawString(font, "Score:" + Score, new Vector2(10, 470), Color.White);
            switch (gamestate)
            {
                case GameState.GameOver:

                    minutes=TimePassed.X.ToString();
                    if (TimePassed.X < 10)
                    {
                        minutes = "0" + minutes;
                    }

                    seconds=TimePassed.Y.ToString();
                    if (TimePassed.Y < 10)
                    {
                        seconds = "0" + seconds;
                    }

                        spriteBatch.DrawString(font, "You survived in " + minutes + ":" + seconds, SurvivedPlacement, Color.White);
                        spriteBatch.DrawString(font, "Score:" + Score, new Vector2(SurvivedPlacement.X, SurvivedPlacement.Y+50), Color.White);
                   

                    spriteBatch.DrawString(font, "HIGHSCORES:", new Vector2(500,SurvivedPlacement.Y), Color.White);

                    for (int i = 0; i < 10; i++)
                    {
                        spriteBatch.DrawString(font, (i+1)+" : "+Sally.GetScore(i), new Vector2(520, SurvivedPlacement.Y + 30*(i+1)), Color.White);
                    }



                    spriteBatch.DrawString(font, minutes + ":" + seconds, new Vector2(600, 470), Color.White);

                    break;

                case GameState.Playing:
                    minutes = (gameTime.TotalGameTime-TotalPauseTime).Minutes.ToString();
                    if ((gameTime.TotalGameTime - TotalPauseTime).Minutes < 10)
                    {
                        minutes = "0" + minutes;
                    }

                    seconds = (gameTime.TotalGameTime - TotalPauseTime).Seconds.ToString();
                    if ((gameTime.TotalGameTime - TotalPauseTime).Seconds < 10)
                    {
                        seconds = "0" + seconds;
                    }

                    spriteBatch.DrawString(font, minutes + ":" + seconds, new Vector2(600, 470), Color.White);
                    break;
            }
        }
    }
}
