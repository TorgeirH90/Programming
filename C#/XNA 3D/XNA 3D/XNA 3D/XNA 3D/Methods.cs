using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNA_3D
{
    public class Methods
    {
        GlobalValues G;
        public Methods(GlobalValues G)
        {
            this.G = G;
        }

        public void DrawTheMatrix(Model DModel, Matrix ChangeMatrix, Vector3 Pos)
        {
            Matrix[] transforms = new Matrix[DModel.Bones.Count];
            DModel.CopyAbsoluteBoneTransformsTo(transforms);

            //Draw model with all its meshes
            foreach (ModelMesh mesh in DModel.Meshes)//Every mesh in MyModel
            {

                //Mesh Orientation and camera and projection
                foreach (BasicEffect effect in mesh.Effects)
                {

                    effect.EnableDefaultLighting();

                    //Sets up the posibillity to use transformatiion on the G.myModelObject
                    effect.World
                        = transforms[mesh.ParentBone.Index]
                        * ChangeMatrix;

                    effect.View = Matrix.CreateLookAt(G.CamPos, G.ship.Position, Vector3.Up);
                    //                                                                                            Near  Far   Wherever you are
                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(G.Fov), G.aspectRatio, 1.0f, 100000);

                }
                mesh.Draw();
            }

        }//End draw matrix

        public Vector3 SphereToChartesian(Vector3 CartCoor)//Page 32 Orange book
        {
            Vector3 SpherCoor = new Vector3();
            SpherCoor.X = CartCoor.X * ((float)Math.Cos(CartCoor.Y)) * ((float)Math.Sin(CartCoor.Z));

            SpherCoor.Z = -CartCoor.X * ((float)Math.Sin(CartCoor.Y)) * ((float)Math.Sin(CartCoor.Z));

            SpherCoor.Y = CartCoor.X * ((float)Math.Cos(CartCoor.Z));

            return SpherCoor;

        }
    }
}
