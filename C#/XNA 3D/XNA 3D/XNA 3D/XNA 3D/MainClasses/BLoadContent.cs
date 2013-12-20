using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace XNA_3D.MainClasses
{
    class LoadContent
    {
        SpriteBatch spriteBatch;
        private GlobalValues G;
        GraphicsDevice DeviceG;


        public LoadContent(GlobalValues G)
        {
            // TODO: Complete member initialization
            this.G = G;
            
        }

        public void Load(ref SpriteBatch SB, GraphicsDevice DeviceG, GraphicsDeviceManager graphics, ContentManager Content)
        {
            spriteBatch = SB;
            //G.Utedo = Texture2D.FromStream(DeviceG, TitleContainer.OpenStream("Content/utedo_map")); 
            //G.myModel = Content.Load<Model>("Wedge");
            G.ship.Model = Content.Load<Model>("Content/Wedge/Wedge");//Mad inconsistency incoming
            G.BulletModel = Content.Load<Model>("Content/Sphere/BrickoSphere1");
            G.EnemycubeModel= Content.Load<Model>("Content/Square/Cube");
            //G.sphere = new Objects.Sphere(G.BulletModel, 0,);
            G.aspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;


            //To be taken away
            G.ball = new Objects.Sphere(G.BulletModel, G.ship.Yrot, new Vector3(0,0,-75));//100,100,-75
            G.ball.move = false;
            
            Random rnd = new Random();

            for (int i = 0; i < 100; i++)
            {
                int ZCor = rnd.Next(20000) - 20000;
                int XCor = rnd.Next(20000) - 10000;
                G.Cubes.Add(new Objects.Enemycube(G.EnemycubeModel, new Vector3(XCor, 0, ZCor)));
            }
            G.Cubes.Add(new Objects.Enemycube(G.EnemycubeModel, new Vector3(0, 0, 0)));
            G.Straw = new Objects.StrawCube(G);//META!
        }

        private Texture2D LoadImage(GraphicsDevice DeviceG, string Path)
        {
            return Texture2D.FromStream(DeviceG, TitleContainer.OpenStream(Path));
        }
    }
}
