using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    class Animation
    {
        Texture2D spriteStrip;

        float scale;

        int elapsedTime;

        int frameTime;

        int frameCount;

        int currentFrame;

        Color color;

        Rectangle sourceRect = new Rectangle();

        Rectangle destinationRect = new Rectangle();

        public int frameWidth;

        public int frameHeigth;

        public bool Active;

        public bool Looping;

        public Vector2 position;

        public void Initialize(Texture2D texture, Vector2 Position, int frameWidth, int frameHeigth, int frameCount,  int frameTime, Color color, float scale, bool looping)
        {//i liek variebles
            this.color = color;
            this.frameWidth = frameWidth;
            this.frameHeigth = frameHeigth;
            this.frameCount = frameCount;
            this.frameTime = frameTime;
            this.scale = scale;

            Looping = looping;
            Position = position;
            spriteStrip = texture;

            //Set time to zero
            elapsedTime = 0;
            currentFrame = 0;

            Active = true;




        }

        public void Update(GameTime gameTime)
        {


            if (Active == false)
            {
                return;
            }

            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            //if larger than FrameTime-->switch
            if (elapsedTime > frameTime)
            {
                currentFrame++;
                //if currentFrame is equal to frameCount
                if (currentFrame == frameCount)
                {
                    currentFrame = 0;
                    if (Looping == false)
                    {
                        Active = false;
                    }

                }
                
                elapsedTime = 0;
                
            }

            sourceRect = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeigth);

            destinationRect = new Rectangle((int)position.X - (int)(frameWidth * scale) / 2, (int)position.Y - (int)(frameHeigth * scale) / 2, (int)(frameWidth * scale), (int)(frameHeigth * scale));

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Active)
            {
                spriteBatch.Draw(spriteStrip, destinationRect, sourceRect, color);
            }
        }




    }
}
