using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace XNA_3D.MainClasses
{
    class Initialize
    {
        private GlobalValues G;


        public Initialize(GlobalValues G)
        {
            // TODO: Complete member initialization
            this.G = G;
        }


        public void Init()
        {
            //Classes
            G.ship = new Objects.Ship(G);
            

            //Values
            G.ElephantPos = Vector3.Zero;
            G.Bullets = new List<Objects.Sphere>();
            G.Cubes = new List<Objects.Enemycube>();
            
        }


    }
}
