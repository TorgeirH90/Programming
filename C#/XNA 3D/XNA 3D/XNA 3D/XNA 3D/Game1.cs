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
//http://msdn.microsoft.com/en-us/library/bb197293%28v=xnagamestudio.31%29.aspx
namespace XNA_3D
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GlobalValues G;
        MainClasses.Initialize Init;
        MainClasses.LoadContent LoadCont;
        MainClasses.Update Updating;
        MainClasses.Draw Drawing;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            G = new GlobalValues();
            Init = new MainClasses.Initialize(G);
            LoadCont = new MainClasses.LoadContent(G);
            Updating = new MainClasses.Update(G);
            Drawing = new MainClasses.Draw(G);
            G.Tools = new Methods(G);
            //this.graphics.PreferredBackBufferWidth = 1920;
            //this.graphics.PreferredBackBufferHeight = 1080;
            //this.graphics.IsFullScreen = true;

            
        }

        protected override void Initialize()
        {

            Init.Init();
            base.Initialize();
        }

     
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            G.GD = GraphicsDevice;
            LoadCont.Load(ref spriteBatch, GraphicsDevice, graphics, Content);
            
            
        }


        protected override void UnloadContent()
        {
        
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();


            Updating.Updating(gameTime);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            //spriteBatch.Begin();
            Drawing.Drawing(gameTime, ref spriteBatch);
            //spriteBatch.End();     

            base.Draw(gameTime);
        }
    }
}
