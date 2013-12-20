using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace XNA_3D.Objects
{
    public struct VertexPositionColorNormal :IVertexType
    {
        public Vector3 Position;
        public Color color;
        public Vector3 Normal;

        public VertexPositionColorNormal(Vector3 Position, Vector3 Normal, Color color)
        {
            this.Position = Position;
            this.Normal = Normal;
            this.color = color;


        }

        //   public static VertexDeclaration VertexDeclaration = new VertexDeclaration
        //   (
        //   new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
        //    new VertexElement(sizeof(float) * 3, VertexElementFormat.Color, VertexElementUsage.Color, 0),
        //    new VertexElement(sizeof(float) * 3 + 4, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0)
        //);
        public static readonly VertexElement[] VertexElements =
    {
        new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
        new VertexElement(sizeof(float)*3, VertexElementFormat.Color, VertexElementUsage.Color, 0),
        new VertexElement(sizeof(float)*4, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0)
    };
        public static readonly VertexDeclaration vertexDeclaration = new VertexDeclaration(VertexElements);

        public VertexDeclaration VertexDeclaration
        {
            get { return vertexDeclaration; }
        }


    }
}
