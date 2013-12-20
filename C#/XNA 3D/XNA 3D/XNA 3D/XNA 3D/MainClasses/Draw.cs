using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNA_3D.MainClasses
{
    class Draw
    {
        private GlobalValues G;
        private Methods DM;


        public Draw(GlobalValues G)
        {
            // TODO: Complete member initialization
            this.G = G;
        }

        public void Drawing(GameTime gameTime, ref SpriteBatch SB)
        {
            ////SB.Draw(G.Utedo, G.CastleLocation, Color.White);
            //Matrix[] transforms = new Matrix[G.myModel.Bones.Count];
            //G.myModel.CopyAbsoluteBoneTransformsTo(transforms);

            ////Draw model with all its meshes
            //foreach (ModelMesh mesh in G.myModel.Meshes)//Every mesh in MyModel
            //{

            //    //Mesh Orientation and camera and projection
            //    foreach (BasicEffect effect in mesh.Effects)
            //    {
                    
            //            effect.EnableDefaultLighting();

            //            //Sets up the posibillity to use transformatiion on the G.myModelObject
            //            effect.World
            //                = transforms[mesh.ParentBone.Index]
            //                * Matrix.CreateRotationX(G.MyModelRotationX)
            //                * Matrix.CreateRotationY(G.MyModelRotationY)
            //                * Matrix.CreateRotationZ(G.MyModelRotationZ)
            //                * Matrix.CreateTranslation(G.MymodelPos);

            //            effect.View = Matrix.CreateLookAt(G.CamPos, G.MymodelPos, Vector3.Up);
            //            //                                                                                            Near  Far   Wherever you are
            //            effect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(G.Fov), G.aspectRatio, 1.0f, 20000);
                    
            //    }
            //    mesh.Draw();
            //}

            G.Tools.DrawTheMatrix(G.ship.Model, G.ship.GetMatrix(), G.ship.Position);
            
            for (int i = 0; i < G.Bullets.Count; i++)
            {
                G.Tools.DrawTheMatrix(G.Bullets[i].Model, G.Bullets[i].GetMatrix(), G.Bullets[i].Position);
            }
            G.Tools.DrawTheMatrix(G.ball.Model, G.ball.GetMatrix(), G.ball.Position);
            G.Straw.Draw();
            for (int i = 0; i < G.Cubes.Count; i++)
            {
                if (G.Cubes[i].CheckDistance(G.ship.Position))
                {
                    G.Tools.DrawTheMatrix(G.Cubes[i].Model, G.Cubes[i].GetMatrix(), G.Cubes[i].Position);
                }
            }
            
            

        }
    }
}
