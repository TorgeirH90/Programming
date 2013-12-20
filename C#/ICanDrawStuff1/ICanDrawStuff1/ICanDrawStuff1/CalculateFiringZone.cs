using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ICanDrawStuff1
{
   public class CalculateFiringZone
    {
        int x;
        int y;
        string Direction;
        Point p = new Point();
        String[] Directions = new String[] { "up", "down", "left", "rigth" };
       public Point GetPoints (int x, int y, string Direction)
        {
            this.x=x;
            this.y=y;
            this.Direction = Direction;
            if (Direction == Directions[0])//up
            {
                x = x + 53;
            }
            else if (Direction == Directions[1])//down
            {
                x = x + 53;
                y = y + 95;
            }
            else if (Direction == Directions[2])//left
            {
                y = y + 43;
            }
            else if (Direction == Directions[3])//rigth
            {
                y = y + 43;
                x = x + 98;
            }
            p.X = x;
            p.Y = y;


            return p;
        }

    }
}
