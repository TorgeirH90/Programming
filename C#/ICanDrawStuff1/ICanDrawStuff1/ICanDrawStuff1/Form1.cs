using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ICanDrawStuff1
{
    public partial class Form1 : Form
    {
        
        
        public Form1()
        {
            InitializeComponent();
        }
        String Direction = "rigth";
        int x = 111;
        int y=109;
        int movement = 10;
        int Shootingpointx;
        int Shootingpointy;
        String[] Directions = new String[] { "up", "down", "left", "rigth" };
        CalculateFiringZone Fire = new CalculateFiringZone();
        Point ShootingPoint= new Point();
       
      
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)//høyre
            {
                if (!(Direction==Directions[3]))
                {
                    Direction = Directions[3];
                    pictureBox1.Image = ICanDrawStuff1.Properties.Resources.airplane11;
                   
                 }
                y = pictureBox1.Location.Y;
                x = pictureBox1.Location.X + movement;

                
                Point p1 = new Point(x, y);
                pictureBox1.Location = p1;
            }
            else if (e.KeyCode == Keys.Left)//venstre
            {
                if (!(Direction == Directions[2]))
                {
                    Direction = Directions[2];
                    pictureBox1.Image = ICanDrawStuff1.Properties.Resources.airplane21;
                    
                }
                y = pictureBox1.Location.Y;
                x = pictureBox1.Location.X - movement;

               
                Point p1 = new Point(x, y);
                pictureBox1.Location = p1;
            }
            else if (e.KeyCode == Keys.Up)//opp
            {
                if (!(Direction == Directions[0]))
                {
                    Direction = Directions[0];
                    pictureBox1.Image = ICanDrawStuff1.Properties.Resources.airplane31;
                   
                }
                y = pictureBox1.Location.Y - movement;
                x = pictureBox1.Location.X;

               
                Point p1 = new Point(x, y);
                pictureBox1.Location = p1;
            }
            else if (e.KeyCode == Keys.Down)//ned
            {
                if (!(Direction == Directions[1]))
                {
                    Direction = Directions[1];
                    pictureBox1.Image = ICanDrawStuff1.Properties.Resources.airplane41;
                    
                }
                y = pictureBox1.Location.Y + movement;
                x = pictureBox1.Location.X;

                
                Point p1 = new Point(x, y);
                pictureBox1.Location = p1;
            }
            else if (e.KeyCode == Keys.Space)//fire!!
            {
                ShootingPoint=Fire.GetPoints(x, y, Direction);
                this.Text = ShootingPoint.X + " " + ShootingPoint.Y;
                Shootingpointx = ShootingPoint.X;
                Shootingpointy = ShootingPoint.Y;
                //this.Paint+=1;
            }
        }
        private void Form1_paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawEllipse(Pens.Black, Shootingpointx, Shootingpointy, 10, 10);
        }
      
        

    }
}
