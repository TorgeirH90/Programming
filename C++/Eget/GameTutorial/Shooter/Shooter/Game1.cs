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
using Microsoft.Xna.Framework.Input.Touch;

namespace Shooter
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;

        KeyboardState currentKeyBoardState;
        KeyboardState previousKeyBoardState;

        // Gamepad states used to determine button presses
        GamePadState currentGamePadState;
        GamePadState previousGamePadState;

        float playerMovementSpeed;

        Texture2D mainBackGround;

        Backgrounds bgLayer1;
        Backgrounds bgLayer2;

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
            // TODO: Add your initialization logic here
            player = new Player();
            playerMovementSpeed = 8.0f;
           
            TouchPanel.EnabledGestures = GestureType.FreeDrag;
            bgLayer1 = new Backgrounds();
            bgLayer2 = new Backgrounds();
            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Vector2 playerPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);
            Animation playerAnimation = new Animation();
            Texture2D playerTexture = Content.Load<Texture2D>("shipAnimation");
            playerAnimation.Initialize(playerTexture, Vector2.Zero, 115, 69, 8, 30, Color.White, 1f, true);

            Vector2 playerPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);
            player.Initialize(playerAnimation, playerPosition);
            //Load Backgrounds
            bgLayer1.Initialize(Content, "bgLayer1", GraphicsDevice.Viewport.Width, -1);
            bgLayer2.Initialize(Content, "bgLayer2", GraphicsDevice.Viewport.Width, -2);

            mainBackGround = Content.Load<Texture2D>("mainbackground");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        private void UpdatePlayer(GameTime gameTime)
        {
            player.Update(gameTime);
            //Phone controls-useless shit
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();
                if (gesture.GestureType == GestureType.FreeDrag)
                {
                    player.Position += gesture.Delta;
                }
            }

            //Thumbstick controls
            player.Position.X += currentGamePadState.ThumbSticks.Left.X * playerMovementSpeed;
            player.Position.Y += currentGamePadState.ThumbSticks.Left.Y * playerMovementSpeed;


            //Keyboard Input
            if ((currentKeyBoardState.IsKeyDown(Keys.Left)) || (currentGamePadState.DPad.Left == ButtonState.Pressed))
            {
                player.Position.X -= playerMovementSpeed;
            }

            if ((currentKeyBoardState.IsKeyDown(Keys.Right)) || (currentGamePadState.DPad.Right == ButtonState.Pressed))
            {
                player.Position.X += playerMovementSpeed;
            }

            if ((currentKeyBoardState.IsKeyDown(Keys.Up)) || (currentGamePadState.DPad.Up == ButtonState.Pressed))
            {
                player.Position.Y -= playerMovementSpeed;
            }

            if ((currentKeyBoardState.IsKeyDown(Keys.Down)) || (currentGamePadState.DPad.Down == ButtonState.Pressed))
            {
                player.Position.Y += playerMovementSpeed;
            }

            //Collision against window border

            player.Position.X = MathHelper.Clamp(player.Position.X, 40, GraphicsDevice.Viewport.Width - player.Width +55);
            player.Position.Y = MathHelper.Clamp(player.Position.Y, 35, GraphicsDevice.Viewport.Height - player.Height+35);


        }



        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)||currentKeyBoardState.IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            previousGamePadState = currentGamePadState;
            previousKeyBoardState = currentKeyBoardState;

            currentKeyBoardState = Keyboard.GetState();
            currentGamePadState = GamePad.GetState(PlayerIndex.One);
            UpdatePlayer(gameTime);
            bgLayer1.Update();
            bgLayer2.Update();


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //Draw Background
            spriteBatch.Draw(mainBackGround, Vector2.Zero, Color.White);
            //Draw the moving backgrounds

            bgLayer1.Draw(spriteBatch);
            bgLayer1.Draw(spriteBatch);


            player.Draw(spriteBatch);



            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
