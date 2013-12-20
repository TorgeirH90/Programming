using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace XNA_3D.Objects
{
    public class StrawCube
    {



        double scale;
        GlobalValues G;
        VertexPositionColorNormal[] Points;
        public StrawCube(GlobalValues G)
        {
            this.G = G;
            scale = 1;
            //The cube
            int Left=-100;
            int Right = 100;
            int Up= 100;
            int Down=-100;
            int Front=-100;
            int Back=100;

            Vector3 LeftUpFront = new Vector3(Left, Front, Up);
            Vector3 RightUpFront = new Vector3(Right, Front, Up);
            Vector3 LeftDownFront = new Vector3(Left, Front, Down);
            Vector3 RightDownFront = new Vector3(Right, Front, Down);

            Vector3 LeftUpBack = new Vector3(Left, Back, Up);
            Vector3 RightUpBack = new Vector3(Right, Back, Up);
            Vector3 LeftDownBack = new Vector3(Left, Back, Down);
            Vector3 RightDownBack = new Vector3(Right, Back, Down);

            Vector3[] V3Array= new Vector3[8];
            Vector3 V3ArrayNormal = new Vector3(0, 0, 1);

            V3Array[0]=LeftUpFront;
            V3Array[1]=RightUpFront;
            V3Array[2] = RightDownFront;
            V3Array[3]=LeftDownFront;
            V3Array[4]=LeftUpBack;
            V3Array[5]=RightUpBack;
            V3Array[6] = RightDownBack;
            V3Array[7]=LeftDownBack;

            //VertexPositionColor Points = new VertexPositionColor();
            
            List<VertexPositionColorNormal> pointlist= new List<VertexPositionColorNormal>();
            for(int i=0; i<3;i++)
            {
                pointlist.Add(new VertexPositionColorNormal(V3Array[i], V3ArrayNormal, Color.White));
                pointlist.Add(new VertexPositionColorNormal(V3Array[i+1], V3ArrayNormal, Color.White));

            }
            pointlist.Add(new VertexPositionColorNormal(V3Array[0], V3ArrayNormal, Color.White));
            pointlist.Add(new VertexPositionColorNormal(V3Array[3], V3ArrayNormal, Color.White));
            for (int i = 4; i < 7; i++)
            {
                pointlist.Add(new VertexPositionColorNormal(V3Array[i], V3ArrayNormal, Color.White));
                pointlist.Add(new VertexPositionColorNormal(V3Array[i + 1], V3ArrayNormal, Color.White));


            }
            pointlist.Add(new VertexPositionColorNormal(V3Array[4], V3ArrayNormal, Color.White));
            pointlist.Add(new VertexPositionColorNormal(V3Array[7], V3ArrayNormal, Color.White));
            
            for (int i = 0; i < 4; i++)
            {
                pointlist.Add(new VertexPositionColorNormal(V3Array[i], V3ArrayNormal, Color.White));
                pointlist.Add(new VertexPositionColorNormal(V3Array[i + 4], V3ArrayNormal, Color.White));

            }
            //12

            for (int i = 0; i < 8;i++ )
            {
                pointlist.Add(new VertexPositionColorNormal(V3Array[i], V3ArrayNormal, Color.White));
                pointlist.Add(new VertexPositionColorNormal(new Vector3(0, 0, 0), V3ArrayNormal, Color.White));
            }
            pointlist.Clear();//Screw commenting

            pointlist.Add(new VertexPositionColorNormal(new Vector3(0,1000,0), V3ArrayNormal, Color.White));
            pointlist.Add(new VertexPositionColorNormal(new Vector3(0,-1000,0), V3ArrayNormal, Color.White));
            //Then put the pointlist in the array where it belongs
            G.MaxDrawlines = pointlist.Count / 2;//Set max drawable lines
            G.drawLines = G.MaxDrawlines;
            Points = new VertexPositionColorNormal[pointlist.Count];
            for (int i = 0; i < pointlist.Count; i++)
            {
                Points[i] = pointlist[i];
            }

            //Points[1] = 5;

            //The cube
            G.worldMatrix = Matrix.CreateRotationX(0) * Matrix.CreateRotationY(0);
            G.viewMatrix = Matrix.CreateLookAt(G.CamPos, G.ship.Position, Vector3.Up);
            G.projectionMatrix= Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(G.Fov), G.aspectRatio, 1.0f, 100000);

            G.basicEffect = new BasicEffect(G.GD);
            G.basicEffect.World = G.worldMatrix;
            G.basicEffect.View = G.viewMatrix;
            G.basicEffect.Projection = G.projectionMatrix;

            // primitive color
            G.basicEffect.AmbientLightColor = new Vector3(0.1f, 0.1f, 0.1f);
            G.basicEffect.DiffuseColor = new Vector3(1.0f, 1.0f, 1.0f);
            G.basicEffect.SpecularColor = new Vector3(0.25f, 0.25f, 0.25f);
            G.basicEffect.SpecularPower = 5.0f;
            G.basicEffect.Alpha = 1.0f;

            G.basicEffect.LightingEnabled = false;
            G.basicEffect.TextureEnabled = false;
            G.basicEffect.VertexColorEnabled = true;

        }
        public void reSize(double reScale)
        {
            scale += reScale;
            int Left =(int) (-100 * scale);
            int Right = (int) (100 * scale);
            int Up = (int) (100 * scale);
            int Down = (int) (-100 * scale);
            int Front = (int) (-100 * scale);
            int Back = (int) (100 * scale);

            Vector3 LeftUpFront = new Vector3(Left, Front, Up);
            Vector3 RightUpFront = new Vector3(Right, Front, Up);
            Vector3 LeftDownFront = new Vector3(Left, Front, Down);
            Vector3 RightDownFront = new Vector3(Right, Front, Down);

            Vector3 LeftUpBack = new Vector3(Left, Back, Up);
            Vector3 RightUpBack = new Vector3(Right, Back, Up);
            Vector3 LeftDownBack = new Vector3(Left, Back, Down);
            Vector3 RightDownBack = new Vector3(Right, Back, Down);

            Console.WriteLine("LeftUpFront " + LeftUpFront);
            Console.WriteLine("RightDownBack " + RightDownBack);
            Console.WriteLine("---------------");

            Vector3[] V3Array = new Vector3[8];
            Vector3 V3ArrayNormal = new Vector3(0, 0, 1);

            V3Array[0] = LeftUpFront;
            V3Array[1] = RightUpFront;
            V3Array[2] = RightDownFront;
            V3Array[3] = LeftDownFront;
            V3Array[4] = LeftUpBack;
            V3Array[5] = RightUpBack;
            V3Array[6] = RightDownBack;
            V3Array[7] = LeftDownBack;

            //VertexPositionColor Points = new VertexPositionColor();

            List<VertexPositionColorNormal> pointlist = new List<VertexPositionColorNormal>();
            for (int i = 0; i < 3; i++)
            {
                pointlist.Add(new VertexPositionColorNormal(V3Array[i], V3ArrayNormal, Color.White));
                pointlist.Add(new VertexPositionColorNormal(V3Array[i + 1], V3ArrayNormal, Color.White));

            }
            pointlist.Add(new VertexPositionColorNormal(V3Array[0], V3ArrayNormal, Color.White));
            pointlist.Add(new VertexPositionColorNormal(V3Array[3], V3ArrayNormal, Color.White));
            for (int i = 4; i < 7; i++)
            {
                pointlist.Add(new VertexPositionColorNormal(V3Array[i], V3ArrayNormal, Color.White));
                pointlist.Add(new VertexPositionColorNormal(V3Array[i + 1], V3ArrayNormal, Color.White));


            }
            pointlist.Add(new VertexPositionColorNormal(V3Array[4], V3ArrayNormal, Color.White));
            pointlist.Add(new VertexPositionColorNormal(V3Array[7], V3ArrayNormal, Color.White));

            for (int i = 0; i < 4; i++)
            {
                pointlist.Add(new VertexPositionColorNormal(V3Array[i], V3ArrayNormal, Color.White));
                pointlist.Add(new VertexPositionColorNormal(V3Array[i + 4], V3ArrayNormal, Color.White));

            }
            //12

            for (int i = 0; i < 8; i++)
            {
                pointlist.Add(new VertexPositionColorNormal(V3Array[i], V3ArrayNormal, Color.White));
                pointlist.Add(new VertexPositionColorNormal(new Vector3(0, 0, 0), V3ArrayNormal, Color.White));
            }

            //Then put the pointlist in the array where it belongs
            G.MaxDrawlines = pointlist.Count / 2;//Set max drawable lines
            G.drawLines = G.MaxDrawlines;
            Points = new VertexPositionColorNormal[pointlist.Count];
            for (int i = 0; i < pointlist.Count; i++)
            {
                Points[i] = pointlist[i];
            }
        }

        public void Draw()
        {
            VertexBuffer VB = new VertexBuffer(G.GD, VertexPositionColor.VertexDeclaration, 7, BufferUsage.WriteOnly);
            G.GD.SetVertexBuffer(VB);
            //G.GD.DrawUserPrimitives<VertexPositionColorNormal>(PrimitiveType.LineList,
            //    Points, 0, 4);
            G.GD.DrawUserPrimitives(PrimitiveType.LineList, Points, 0, G.drawLines);//12
            //G.GD.SetVertexBuffer
        }




    }
}
