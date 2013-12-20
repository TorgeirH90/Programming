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

namespace Paratroopers_Mono
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        Vector2 BakkePos;
        Vector2 BulletOrigin;
        Vector2 BulletOriginAtZero;
        Vector2 TurrentOrigin;
        Single TurretROT;
        TimeSpan PreviousMoveTime;
        TimeSpan PreviousFireTime;
        TimeSpan PreviousEnemyTime;
        TimeSpan FireRate;
        TimeSpan EnemyRate;
        TimeSpan MoveRate;
        TimeSpan TripTime;
        TimeSpan PreviousTripTime;
        TimeSpan PauseTimeCooldown;
        TimeSpan TotalPauseTime;
        TimeSpan fpsmeasurement;
        TimeSpan prevFPSmeasurement;
        //Rectangles/Boxy stuff
        Vector2 TurrentUnderdelRect;
        Vector2 TurrentMidRect;
        //Texture
        Texture2D TurrentUnderdel;
        Texture2D YPixel;
        Texture2D Turrent;
        Texture2D TurrentMid;
        Texture2D BulletTexture;
        Texture2D EnemyTexture;
        Texture2D EnemyTexture2;
        Texture2D ParatrooperTexture;
        Texture2D ParachuteTexture;
        Animation2 Background;
        
        SpriteFont font;
        //Classes
        Turret turret;
        Random rnd;
        StatePlayKeyboard PlayKeyboard;
        SpecialFeatures SpecialF;
        Spawner Spawn;
        UpdateLists ListUpdater;
        CollisionDetection CollisionDetect;
        TextOnScreen text;
        Draw draw;
        SaveAndLoadGame Sally;
        StatePauseKeyboard PauseKeyboard;

        //Lists
        List<Bullet> BulletList;
        List<EnemyHelo> ChopperList;
        List<EnemyParatrooper> ParatrooperList;
       
        float MoveLimit;
        int Score;//SCORE!!
        float LineMovement;
        float TurretRotAtSpace;
        int insideoutside;
        int fpscount;
        int fps;
        int FireContinously;
        float GroundRotation;
        Vector2 AmountOfTroopersOnTurret;
        Vector2 TimePassed;
        //int AmountOfTroopersRight;
        bool trippy1;
        bool trippy2;
        bool Retract;
        
        //In UpdateLists.cs
        GameState gamestate;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            IsFixedTimeStep = false;
            //graphics.IsFullScreen = true; //TODO: Flytte alle plasseringsvariabler slik at de passer til en gitt skjerm
            Content.RootDirectory = "Content";
            
        }
        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            //Graphics
            graphics.PreferredBackBufferHeight = 505;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();


            //General
            gamestate = GameState.Playing;
            BakkePos = new Vector2(0, 475);
            GroundRotation = -(float)((Math.PI / 180) * 90);
            rnd = new Random();

            //Extra features
            LineMovement = 0;
            trippy1 = false;
            trippy2 = false;
            Retract = true;
            Background = new Animation2();//          640 448                 //Graphics settings
            Background.Initialize(new Vector2(0, 0), 500, 500, 5, new Rectangle(0,0,800,475), Color.Black, true);

            //FPS
            fps = 0;
            fpscount = 0;
            fpsmeasurement = TimeSpan.FromSeconds(1);
            prevFPSmeasurement = TimeSpan.Zero;

            //Turret
            turret = new Turret();
            TurretRotAtSpace = 0;
            AmountOfTroopersOnTurret = new Vector2(0, 0);//Left and right
            FireContinously = 0;
            BulletOrigin = new Vector2(398f, 427);
            BulletOriginAtZero = BulletOrigin;
            TurrentOrigin = new Vector2(5, 25);//Omrisse av kanonen
            TurrentMidRect = new Vector2(380, 409);
            TurrentUnderdelRect = new Vector2(360, 425);//Plassering for bakken blir 475
            MoveLimit = ((float)(Math.PI / 180)) * 65;//var 88

            //Time
            TimePassed = new Vector2(0, 0);
            TripTime =TimeSpan.FromSeconds(0.5f);
            PreviousTripTime = TimeSpan.Zero;
            PauseTimeCooldown = TimeSpan.Zero;
            TotalPauseTime = TimeSpan.Zero;
            FireRate=TimeSpan.FromSeconds(0.4f);//0.4
            EnemyRate = TimeSpan.FromMilliseconds(1500);
            MoveRate = TimeSpan.FromSeconds(0.00002f);
            PreviousMoveTime = TimeSpan.Zero;
            PreviousEnemyTime = TimeSpan.Zero;
            PreviousFireTime = TimeSpan.Zero;

            //Lists
            BulletList = new List<Bullet>();
            ChopperList = new List<EnemyHelo>();
            ParatrooperList = new List<EnemyParatrooper>();

            //Classes
            PlayKeyboard    = new StatePlayKeyboard();
            SpecialF        = new SpecialFeatures();
            Spawn           = new Spawner();
            ListUpdater     = new UpdateLists();
            CollisionDetect = new CollisionDetection();
            text            = new TextOnScreen();
            draw            = new Draw();
            Sally           = new SaveAndLoadGame();
            PauseKeyboard   = new StatePauseKeyboard();
            //Sally.SaveGame(47);
            Sally.LoadGame();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            TurrentUnderdel = Texture2D.FromStream(GraphicsDevice, TitleContainer.OpenStream("Content/Turrentunderdel.png")); 
            Turrent = Texture2D.FromStream(GraphicsDevice, TitleContainer.OpenStream("Content/TurrentOverdel.png")); 
            TurrentMid = Texture2D.FromStream(GraphicsDevice, TitleContainer.OpenStream("Content/TurretMid.png"));
            //YPixel = Content.Load<Texture2D>("Whitestrip");
            BulletTexture = Texture2D.FromStream(GraphicsDevice, TitleContainer.OpenStream("Content/BulletTed.png"));
            font = Content.Load<SpriteFont>("gameFont");
                //FromStream(GraphicsDevice, TitleContainer.OpenStream("Content/gameFont.spritefont"));
            //Content.Load<SpriteFont>("gameFont");
            //Enemy animation
            EnemyTexture = Texture2D.FromStream(GraphicsDevice, TitleContainer.OpenStream("Content/ChopperAnimation.png"));
            EnemyTexture2 = Texture2D.FromStream(GraphicsDevice, TitleContainer.OpenStream("Content/ChopperAnimation2.png"));
            ParatrooperTexture = Texture2D.FromStream(GraphicsDevice, TitleContainer.OpenStream("Content/Paratrooper.png"));
            ParachuteTexture = Texture2D.FromStream(GraphicsDevice, TitleContainer.OpenStream("Content/Parachute.png"));

            YPixel = Texture2D.FromStream(GraphicsDevice, TitleContainer.OpenStream("Content/Coloredstrip.png"));
            Content.Load<Texture2D>("Coloredstrip");

            //for(int i=0;i<=99;i++)
            //{
            //    Background.AddFrame(Content.Load<Texture2D>("Background/IMG000" + i));
            //}

            turret.Initialize(Turrent, TurrentOrigin, MoveLimit);
            // TODO: use this.Content to load your game content here
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            { this.Exit(); }

            fpscount++;
            if (gameTime.TotalGameTime.TotalSeconds - prevFPSmeasurement.TotalSeconds > fpsmeasurement.TotalSeconds)
            {
                fps = fpscount;
                fpscount = 0;
                prevFPSmeasurement = gameTime.TotalGameTime;
            }
            switch (gamestate) 
            {
                case GameState.Playing:
            
                //SpecialFeatures
                SpecialF.LineMovement
                    (
                        ref  Retract,
                        ref  LineMovement
                    );


                //Spawner.cs
                Spawn.Spawning
            (
                ref  gameTime,
                ref  PreviousEnemyTime,
                ref  EnemyRate,
                ref  ChopperList,
                ref  rnd,
                ref  EnemyTexture,
                ref  EnemyTexture2,
                ref  ParatrooperTexture,
                ref  ParachuteTexture,
                ref  ParatrooperList,
                ref  TotalPauseTime
            );

                //UpdateLists.cs
                ListUpdater.Update
                    (
                        ref  BulletList,
                        ref gameTime,
                        ref ParatrooperList,
                        ref AmountOfTroopersOnTurret,
                        ref TimePassed,
                        ref gamestate,
                        ref Sally,
                        ref Score,
                        ref TotalPauseTime,
                        ref  ChopperList
                    );

                //CollisionDetection.cs
                CollisionDetect.Collision
                    (
                        ref BulletList,
                        ref ChopperList,
                        ref ParatrooperList,
                        ref Score,
                        ref EnemyRate
                    );

                //Keys
                //Fil--> StatePlayKeyboard.cs
                PlayKeyboard.PlayInput
                   (
                       ref  gameTime,
                       ref  PreviousTripTime,
                       ref  TripTime,
                       ref  trippy1,
                       ref  trippy2,
                       ref  TurretROT,
                       ref  turret,
                       ref  BulletOrigin,
                       ref  BulletOriginAtZero,
                       ref  PreviousFireTime,
                       ref  MoveLimit,
                       ref  FireRate,
                       ref  FireContinously,
                       ref  TurrentOrigin,
                       ref  BulletTexture,
                       ref  BulletList,
                       ref  TurretRotAtSpace,
                       ref  gamestate,
                       ref  PauseTimeCooldown,
                       ref  TotalPauseTime
                   );
                
              
           break;//GameState==Playing
                case GameState.SetScore:
           Sally.SaveGame(Score);
           gamestate = GameState.GameOver;

           break;
                case GameState.Pause:
           PauseKeyboard.PauseInput
               (
                ref gamestate,
                ref PauseTimeCooldown,
                ref gameTime,
                ref TotalPauseTime
               );
                    


           break;
             
            }
            Background.Update(gameTime);
            base.Update(gameTime);
        }
        
        

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            //Background.Draw(spriteBatch);


            draw.Drawing
                (
                ref  spriteBatch,
                ref  YPixel,
                ref  BakkePos,
                ref  GroundRotation,
                ref  turret,
                ref  TurrentUnderdel,
                ref  TurrentUnderdelRect,
                ref  TurrentMidRect,
                ref  TurrentMid,
                ref  ChopperList,
                ref  BulletList,
                ref  ParatrooperList
                );
           
            


            SpecialF.DrawExtraLines
                (
                ref  trippy1,
                ref  trippy2,
                ref  spriteBatch,
                ref  YPixel,
                ref  turret,
                ref  insideoutside,
                ref  LineMovement
                );

            //TextOncreen.cs
            text.text
                (
                    ref  gamestate,
                    ref  TimePassed,
                    ref  spriteBatch,
                    ref  font,
                    ref  Score,
                    ref  gameTime,
                    ref  Sally,
                    ref  TotalPauseTime,
                    ref EnemyRate
                );

            
            

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
