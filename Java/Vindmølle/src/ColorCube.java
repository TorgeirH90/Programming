import java.awt.*;
import java.awt.event.*;
import javax.media.j3d.*;
import javax.vecmath.*;

public class ColorCube extends Object {
//	FORAN
	static float xOVF= 0f; static float yOVF= 1.0f; static float zOVF= 0f;
	static  float xOHF= 0f;static  float yOHF= 1.0f;static  float zOHF= 0f;
	static  float xNVF= -1.0f;static  float yNVF= -1.0f;static  float zNVF= 1.0f;
	static  float xNHF= 1.0f;static  float yNHF= -1.0f;static  float zNHF= 1.0f;
	 
//	 BAK
	static  float xOVB= 0f;static  float yOVB= 1.0f;static  float zOVB= 0f;
	static  float xOHB= 0f;static  float yOHB= 1.0f;static  float zOHB= 0f;
	static  float xNVB= -1.0f;static  float yNVB= -1.0f;static  float zNVB= -1.0f;
	static  float xNHB= 1.0f;static  float yNHB= -1.0f;static  float zNHB= -1.0f;
	
    private static final float[] verts = {
    // front face RØD
         xOVF, yOVF,  zOVF,                             xNVF,  yNVF,  zNVF,
        xNHF,  yNHF,  zNHF,                            xOHF, yOHF,  zOHF,
    // back face GRØNN
        xOVB, yOVB, zOVB,                            xOHB,  yOHB, zOHB,
         xNHB,  yNHB, zNHB,                             xNVB, yNVB, zNVB,
    // right face BLÅ
         xOHF, yOHF, zOHF, /*nede høyre bak*/       xNHF,  yNHF, zNHF,//oppe høyre bak
         xNHB,  yNHB,  zNHB, /*oppe høyre foran*/       xOHB, yOHB,  zOHB,//oppe høyre bak
    // left face YELLOW
       xOVB, yOVB,  zOVB,                            xNVB,  yNVB,  zNVB,
        xNVF,  yNVF, zNVF,                            xOVF, yOVF, zOVF,
    // top faceROSA-ISH
         xOVF,  yOVF,  zOVF,                             xOHF,  yOHF, zOHF,
        xOHB,  yOHB, zOHB,                           xOVB,  yOVB,  zOVB,
    // bottom face LYSEBLÅ
        xNVF, yNVF,  zNVF,                            xNVB, yNVB, zNVB,
         xNHB, yNHB, zNHB,                             xNHF, yNHF,  zNHF,
    };
    private static final float[] colors = {
    // front face (red)
        1.0f, 0.0f, 0.0f,                            1.0f, 0.0f, 0.0f,
        1.0f, 0.0f, 0.0f,                            1.0f, 0.0f, 0.0f,
    // back face (green)
        0.0f, 1.0f, 0.0f,                            0.0f, 1.0f, 0.0f,
        0.0f, 1.0f, 0.0f,                            0.0f, 1.0f, 0.0f,
    // right face (blue)
        0.0f, 0.0f, 1.0f,                            0.0f, 0.0f, 1.0f,
        0.0f, 0.0f, 1.0f,                            0.0f, 0.0f, 1.0f,
    // left face (yellow)
        1.0f, 1.0f, 0.0f,                            1.0f, 1.0f, 0.0f,
        1.0f, 1.0f, 0.0f,                            1.0f, 1.0f, 0.0f,
    // top face (magenta)rosa-ish
        1.0f, 0.0f, 1.0f,                            1.0f, 0.0f, 1.0f,
        1.0f, 0.0f, 1.0f,                            1.0f, 0.0f, 1.0f,
    // bottom face (cyan)lyseblå
        0.0f, 1.0f, 1.0f,                            0.0f, 1.0f, 1.0f,
        0.0f, 1.0f, 1.0f,                            0.0f, 1.0f, 1.0f,
    };
    
    
    private static final float[] verts2 = {
    	1,0,-1f,		-1f,0,-1f,			0,6,0,	
    	1,0,1,			1,0,-1f,			0,6,0,
    	-1f,0,1,		1,0,1,				0,6,0,
    	-1f,0,-1f,		-1f,0,1,			0,6,0,

    	
    };
    private Shape3D shape;

    @SuppressWarnings("restriction")
	public ColorCube() {
//        QuadArray cube = new QuadArray(24,QuadArray.COORDINATES | QuadArray.COLOR_3);
//      cube.setCoordinates(0, verts);
//      cube.setColors(0, colors);
    	TriangleArray trekant = new TriangleArray(12, TriangleArray.COORDINATES);
    	PolygonAttributes pa= new PolygonAttributes();
    	Appearance appear=new Appearance();
    	pa.setCullFace(PolygonAttributes.CULL_NONE);
    	pa.setPolygonMode(PolygonAttributes.POLYGON_LINE);
    	
    	ColoringAttributes ca = new ColoringAttributes();
    	ca.setColor(1.0f, 0.0f, 0.0f);
    	
    	
    	appear.setPolygonAttributes(pa);

    	appear.setColoringAttributes(ca);
    	
        trekant.setCoordinates(0, verts2);

        shape = new Shape3D(trekant, appear);
    }

    public Shape3D getShape() {
        return shape;
    }
}