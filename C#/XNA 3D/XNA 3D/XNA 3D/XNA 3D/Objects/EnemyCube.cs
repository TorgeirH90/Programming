using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace XNA_3D.Objects
{
    public class Enemycube
    {
        public Model Model;
        public Vector3 Position;
        //public float Xrot;
        //public float Yrot;
        //public float Zrot;
        public bool move;
        public bool Draw;

        public Enemycube(Model model, Vector3 Startpos)
        {
            //Xrot = 0;
            //Yrot = 0;
            //Zrot = 0;
            Position = Startpos;
            Model = model;
            
            move = true;
        }
        public Matrix GetMatrix()//Standarized location transmitter
        {
            return Matrix.CreateTranslation(Position);

        }
        public bool CheckDistance(Vector3 Distance)
        {
            Distance -= Position;
            return (Distance.Length() < 40000);//Instead of if/else
            
        }
        public BoundingBox Collision()
        {
            Vector3 Middle= new Vector3(Position.X+100,Position.Y+100,Position.Z-75);
            Vector3 abc = new Vector3(80);
            BoundingBox bb= new BoundingBox(Middle - new Vector3(40), Middle + new Vector3(40));
            return bb;
        }
        public Vector4 Collisionbs()
        {
            Vector3 Middle = new Vector3(Position.X + 100, Position.Y + 100, Position.Z - 75);
            //BoundingSphere bb = new BoundingSphere();
            
            //bb.Center = Middle;
            //bb.Radius = 80;// Model.Meshes[0].BoundingSphere.Radius;
            return new Vector4(Middle, 80);
        }
        public void Update(Vector3 Distance)
        {

        }
    }
}
