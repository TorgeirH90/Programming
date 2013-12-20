using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSCW.MainClasses
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
            G.a = 0;
            G.b = 100;
        }


    }
}
