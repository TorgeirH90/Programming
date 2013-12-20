#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;


#endregion

namespace KSCW
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        MainClasses.GlobalValues G;
        MainClasses.Initialize Init;
        MainClasses.LoadContent LoadCont ;
        MainClasses.Update Updating;
        MainClasses.Draw Drawing;



        public Game1():base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            G = new MainClasses.GlobalValues();
            Init = new MainClasses.Initialize(G);
            LoadCont = new MainClasses.LoadContent(G);
            Updating = new MainClasses.Update(G);
            Drawing = new MainClasses.Draw(G);

            //OpenTK.GameWindow abc=OpenTK.GameWindow;
            //Type type = typeof(OpenTKGameWindow);
            //System.Reflection.FieldInfo field = type.GetField("window", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            
            //   abc=field.GetValue(this.Game) as OpenTK.GameWindow;

            //graphics.PreferredBackBufferWidth = 1900;
            //graphics.PreferredBackBufferHeight = 1000;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            //Sets position of the window
            
        }

        protected override void Initialize()
        {
    
            Init.Init();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LoadCont.Load(ref spriteBatch, GraphicsDevice);

        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))Exit();
            
            Updating.Updating(gameTime);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            Drawing.Drawing(gameTime, ref spriteBatch);
            spriteBatch.End();                       
            

            base.Draw(gameTime);
        }
    }
}
