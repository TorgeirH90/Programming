using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNA_3D.Objects
{
    public class Ship
    {
        public Model Model;
        public Vector3 Position;
        public float Xrot;
        public float Yrot;
        public float Zrot;
        public int speed;
        public float scale;
        public Vector3 Direction;
        public Vector3 Banking;
        public float XYBank;
        GlobalValues G;

        Matrix RotX;
        Matrix RotY;
        Matrix RotZ;

        Matrix DirectionMatrix;



        public Ship(GlobalValues G)
        {
            this.G = G;
            Xrot = 0;
            Yrot = 0;
            Zrot = 0;
            Position = new Vector3(0, 50, 0);
            Banking = new Vector3(speed, (float)(Math.PI / 2), (float)(Math.PI / 2));
            speed = 0;
            Direction = new Vector3(speed, (float)(Math.PI / 2), (float)(Math.PI / 2));//Straight ahead!
            speed = 75;
            scale = 1;
            XYBank = 0;
            RotX = new Matrix();
            RotY = new Matrix();
            RotZ = new Matrix();
            RotX = Matrix.CreateTranslation(0, 0, 0);
            RotY = Matrix.CreateTranslation(0, 0, 0);
            RotZ = Matrix.CreateTranslation(0, 0, 0);
            DirectionMatrix = Matrix.CreateTranslation(1, 1, 1);
            
        }
        public void Reset()
        {
            Xrot = 0;
            Yrot = 0;
            Zrot = 0;
            Position = Vector3.Zero;
            
        }
        public void Speedup()
        {
            speed = 2000;//HYPERSPEED!
        }

        public void SpeedDown()
        {
            speed = 100;
        }

        public BoundingSphere GetBox()
        {
            BoundingSphere bb = new BoundingSphere();
            return bb;
        }

        public void NoseDown(bool Down)
        {
            if (Down)
            {
                Direction.Z += 0.03f;
                //Xrot -= 0.03f;
                Xrot = -0.03f;
                
            }
            else
            {
                Direction.Z -= 0.03f;
                //Xrot += 0.03f;
                Xrot = 0.03f;
            }
            //RotX = Matrix.CreateRotationX(Xrot);
            DirectionMatrix *= Matrix.CreateFromAxisAngle(DirectionMatrix.Right, Xrot);
        }
        public void TurnLeft(bool Left)
        {
            if (Left)
            {
                Direction.Y += 0.03f;
                //Yrot += 0.03f;
                Yrot = 0.03f;
            }
            else
            {
                Direction.Y -= 0.03f;
                //Yrot -= 0.03f;
                Yrot = -0.03f;
            }
            //RotY = Matrix.CreateRotationY(Yrot);
            DirectionMatrix *= Matrix.CreateFromAxisAngle(DirectionMatrix.Up, Yrot);
        }

        public void BankLeft(bool Left)//LEFT HANDED MASTERRACE! also this goan fuk ting up
        {
            
            if (Left)
            {
                //Rotate direction left
                


                //XYBank += 0.1f;
                //Banking.Z += 0.1f;
                //Banking.Y += 0.1f;
                //Direction.Y += 0.03f;
                //Zrot += 0.1f;
                Zrot = 0.1f;
            }
            else
            {
                //XYBank -= 0.1f;
                //Banking.Z -= 0.1f;
                //Banking.Y -= 0.1f;
                //Direction.Y -= 0.03f;
                //Zrot -= 0.1f;
                Zrot = -0.1f;
            }
            //RotZ = Matrix.CreateRotationZ(Zrot);
            DirectionMatrix *= Matrix.CreateFromAxisAngle(DirectionMatrix.Forward, Zrot);
        }


        public Matrix GetMatrix()
        {
            


            Position += G.Tools.SphereToChartesian(Direction);
            return 
                 //* Matrix.CreateTranslation(Position)
                  Matrix.CreateTranslation(Position)
                 //* Matrix.CreateTranslation(Model.Meshes[0].BoundingSphere.Center)
                 * DirectionMatrix
                 //* RotX
                 //* RotY
                 //* RotZ
                 //* Matrix.CreateTranslation(-Position)
                 //* Matrix.CreateTranslation(-Model.Meshes[0].BoundingSphere.Center)
                 //* Matrix.CreateRotationZ(XYBank)
                 ;//* Matrix.CreateScale(scale);
            
        }
    }
}
