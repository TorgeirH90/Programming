using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Windows.Forms;
//using System.Drawing;

namespace FraktalFirkant
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D WB;

        //List<Texture2D> txlist= new List<Texture2D>();
        List<Point> poslist = new List<Point>();
        List<Point> sizelist = new List<Point>();
        Point StartPoint = new Point(800, 800);
        //Point TempPoint1;
        //Point TempPoint2;
        TimeSpan ButtonCoolDown =TimeSpan.FromSeconds(0); 
        int StopPoint=1;
        int LastStopPoint=99;
        int It = 1;//TimesIterated
        Point UpperLeft = new Point();

        Point MidPoint;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            setScreen();
            WB = Content.Load<Texture2D>("WhitePixel");
            MidPoint = new Point(StartPoint.X / 3, StartPoint.Y / 3);
            
            AddBox(MidPoint.X, MidPoint.Y,new Point( MidPoint.X, MidPoint.Y));
            UpperLeft.X = MidPoint.X / 3;
            UpperLeft.Y = MidPoint.Y / 3;
            MuhSides(MidPoint, MidPoint);
            It++;
            //int Limit = poslist.Count();
            //for (int i = StopPoint; i < Limit; i++)
            //{
            //    MuhSides(poslist[i], sizelist[i]);
            //}
            //StopPoint = poslist.Count();



                base.Initialize();
        }
        public void MuhSides(Point P, Point Size)
        {
            Point NSize= new Point(Size.X/3,Size.Y/3);
            int Left =P.X-(2*UpperLeft.X);
                //P.X-((2*It)*(P.X/(3*It)));
            int Mid1=P.X+UpperLeft.X;
            int Right = P.X + Size.X + UpperLeft.X;
            int Up = P.Y-(2*UpperLeft.Y);
                //P.Y-((2*It)*(P.Y/(3*It)));
            int Mid2 = P.Y + UpperLeft.Y;
            int Down = P.Y + Size.Y + UpperLeft.Y;

            //Begins from the upper left and contintues right
            //Row 1
            AddBox(Left, Up, NSize);
            AddBox(Mid1, Up, NSize);
            AddBox(Right, Up, NSize);
            
            //Row2
            AddBox(Left, Mid2, NSize);
            //Empty
            AddBox(Right, Mid2, NSize);

            //Row3
            AddBox(Left, Down, NSize);
            AddBox(Mid1, Down, NSize);
            AddBox(Right, Down, NSize);


        }


        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        
        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape)) { this.Exit(); }


            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Space)&&(gameTime.TotalGameTime.Seconds-ButtonCoolDown.Seconds>0.5))
            {
                Console.WriteLine("Heyoooo");
                int Limit = poslist.Count();
                LastStopPoint = Limit-1;

                UpperLeft.X = poslist[StopPoint].X /3;
                UpperLeft.Y = poslist[StopPoint].Y / 3;
                for (int i = StopPoint; i < Limit; i++)//Stopppoint was Limit (i<Limit)
                {
                    MuhSides(poslist[i], sizelist[i]);
                    StopPoint = i;
                }
                It++;
                
                ButtonCoolDown=gameTime.TotalGameTime;
            }


            if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.H) && (gameTime.TotalGameTime.Seconds - ButtonCoolDown.Seconds > 0.1))
            {
                Console.WriteLine("asdsa");

                StopPoint++;
                UpperLeft.X = poslist[StopPoint].X / 3;
                UpperLeft.Y = poslist[StopPoint].Y / 3;

                MuhSides(poslist[StopPoint], sizelist[StopPoint]);
                LastStopPoint = poslist.Count()-9;
                
                

                ButtonCoolDown = gameTime.TotalGameTime;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            for (int c = 0; c < poslist.Count(); c++)
            {
                if (c > LastStopPoint)
                {
                    spriteBatch.Draw(WB, new Rectangle(poslist[c].X, poslist[c].Y, sizelist[c].X, sizelist[c].Y), Color.Blue);
                }
                else
                {
                    spriteBatch.Draw(WB, new Rectangle(poslist[c].X, poslist[c].Y, sizelist[c].X, sizelist[c].Y), Color.White);
                }

            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void setScreen()
        {
            var form = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(this.Window.Handle);
            form.Location = new System.Drawing.Point(1517, 0);//1517 makes screen be at the middle of second screen
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();
        }

        public void AddBox(int X, int Y, Point Size)
        {
            poslist.Add(new Point(X,Y));
            sizelist.Add(Size);
        }
    }
}
