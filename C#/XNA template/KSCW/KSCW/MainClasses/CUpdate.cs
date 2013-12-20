using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace KSCW.MainClasses
{
    class Update
    {
        private GlobalValues G;



        public Update(GlobalValues G)
        {
            // TODO: Complete member initialization
            this.G = G;
        }

        public void Updating(GameTime GT)
        {
            G.a++;
            G.b--;

            Console.WriteLine("A:" + G.a);
            Console.WriteLine("B:" + G.b);
        }
    }
}
