using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Paratroopers_Mono
{
    class Animation2
    {
        List<Texture2D> Spritestrip;
        int elapsedTime;
        int frameTime;
        int frameCount;
        int currentFrame;
        Color color;
        Rectangle sourceRect;
        Rectangle destRect;
        public int frameWidth;
        public int frameHeigth;
        public bool Active;
        public bool Looping;
        public Vector2 Position;
        

        //Every file NEEDS to be same size
        //                      framePos            How large each frame is       Milliseconds      No idea      Not implemented
        public void Initialize(Vector2 Position, int frameWidth, int frameHeigth, int frameTime,Rectangle Destination, Color colour, bool Looping)
        {
            this.color = colour;
            this.frameWidth = frameWidth;
            this.frameHeigth = frameHeigth;
            this.frameCount = 0;
            this.frameTime = frameTime;
            this.Looping = Looping;
            this.Position = Position;
            Spritestrip = new List<Texture2D>();

            elapsedTime = 0;
            currentFrame = 0;
            Active = true;


            sourceRect = new Rectangle(0, 0, frameWidth, frameHeigth);
            destRect = Destination;
         }

        //Every frame needs to be put in the right order
        public void AddFrame(Texture2D Frame)
        {
            Spritestrip.Add(Frame);
            frameCount++;
        }

        public void Update(GameTime gameTime)
        {
            if (!Active)
            {
                return;
            }

            //Vil mulig gjøre denne om til TimeSpan
            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsedTime > frameTime)
            {
                currentFrame++;
                if (currentFrame == frameCount)
                {
                    currentFrame = 0;
                    //if (!Looping) //er ikke i bruk
                    //{
                    //    Active = false;
                    //}
                }
                elapsedTime = 0;
            }
            


        }

        public void UpdateNotChangeFrame(GameTime gameTime)
        {
            sourceRect.X = currentFrame * frameWidth;
            sourceRect.Width = frameWidth;
            sourceRect.Height = frameHeigth;

            destRect.X = (int)Position.X;
            destRect.Y = (int)Position.Y;
            destRect.Width = frameWidth;
            destRect.Height = frameHeigth;
        }

        public void ChangeFrame()
        {
            if (!Active)
            {
                return;
            }
            currentFrame++;
            if (currentFrame == frameCount)
            {
                currentFrame = 0;
                //if (!Looping) //er ikke i bruk
                //{
                //    Active = false;
                //}
            }
            

            
        }

        
        public void Draw (SpriteBatch spritebatch)
        {

            if (Active)
            {
                
                    spritebatch.Draw(Spritestrip[currentFrame], destRect, sourceRect, Color.White);
                
            }

        }
    }
}
