using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace XNA_3D.Objects
{
    public class Sphere
    {
        public Model Model;
        public Vector3 Position;
        public float Xrot;
        public float Yrot;
        public float Zrot;
        public float Direction;
        public bool move;

        public Sphere(Model model, float direction, Vector3 Startpos)
        {
            Xrot = 0;
            Yrot = 0;
            Zrot = 0;
            Position = Startpos;
            Model = model;
            Direction = direction;
            move = true;
        }
        public Matrix GetMatrix()
        {
            return Matrix.CreateRotationX(Xrot)
                 * Matrix.CreateRotationY(Yrot)
                 * Matrix.CreateRotationZ(Zrot)
                 * Matrix.CreateTranslation(Position);

        }
        public bool Update(Vector3 Distance)//Distance from ship
        {//Sets new position, makes the bullet move


            if(move)
            {
                Position.Z -= 10;
                Position.Z -= (float)(Math.Cos(Direction) * 200);
                Position.X -= (float)(Math.Sin(Direction) * 200);
            }

            Distance -= Position;
            return (Distance.Length()<20000);
        }
        public Vector4 Collision()
        {
            
            //BoundingSphere bb = new BoundingSphere();
            //bb.Center = Position;
            //bb.Radius = 40;// Model.Meshes[0].BoundingSphere.Radius;
            return new Vector4(Position, 40); ;
        }
    }
}
