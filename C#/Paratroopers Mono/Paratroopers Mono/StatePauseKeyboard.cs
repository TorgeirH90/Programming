using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Paratroopers_Mono
{
    class StatePauseKeyboard
    {
        public void PauseInput
            (
            ref GameState gamestate,
            ref TimeSpan  PauseTimeCooldown,
            ref GameTime gameTime,
            ref TimeSpan TotalPauseTime
            )
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (gameTime.TotalGameTime - PauseTimeCooldown > TimeSpan.FromSeconds(1))
                {
                    gamestate = GameState.Playing;
                    TotalPauseTime += gameTime.TotalGameTime - PauseTimeCooldown;
                    PauseTimeCooldown = gameTime.TotalGameTime;
                    
                }
            }



        }
    }
}
