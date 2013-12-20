using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace XNA_3D
{
   public class GlobalValues
    {
       //
        //Ingen metoder her
       //Classes
       public Methods Tools;
       public Objects.Ship ship;
       public Objects.Sphere sphere;
       public Objects.StrawCube Straw;

       //Spheres VS Cubes?
       //Lists
       public List<Objects.Sphere> Bullets;
       public List<Objects.Enemycube> Cubes;

       //Models 
       public Model BulletModel;
       public Model EnemycubeModel;

       public int a;
       public int b;
       public Texture2D Utedo;
       public float aspectRatio;

       //String cube
       public GraphicsDevice GD;
       public Matrix worldMatrix;
       public Matrix viewMatrix;
       public Matrix projectionMatrix;
       public VertexPositionNormalTexture[] cubeVertices;
       public VertexDeclaration vertexDeclaration;
       public VertexBuffer vertexBuffer;
       public BasicEffect basicEffect;
       public int drawLines = 1;
       public int MaxDrawlines = 1;
       public bool drawlingekeydown1=false;
       public bool drawlingekeydown2 = false;


       
       //Cam
       public Vector3 CamPos = new Vector3(0, 500, 10000);
       public int Fov = 45;
       public int stdfov = 45;
       public int speedFov = 60;
       public float CamRot=(float)(Math.PI/2);
       public int Zoom = 10000;

       //Bullet temp vars
       //X: -35
       public Vector3 FrontBullpos=new Vector3(-35,-50,-1020);
       public Vector3 SideLeftBullpos = new Vector3(-870, 0.32f, 1.25f);
       public Vector3 SideRightBullpos = new Vector3(-780, -0.36f, -1.25f);

       public Vector3 Bullpos = new Vector3(-35, -50, -1020);

       //3d rot testing
       public Vector3 Spherelocation = new Vector3(0,0,0);
       public Objects.Sphere ball;

       //Speed up effect
       public bool Speedup = false;
       public bool SpeedDown = false;
       public bool Speeding = false;
       public TimeSpan SpeedOnOffTimer = new TimeSpan();

       //Turning
       public float MaxYTurn = MathHelper.ToRadians(15);
       public float YTurn = 0.01f;

       public Model ElephantMod;
       public Vector3 ElephantPos;

    }
}

